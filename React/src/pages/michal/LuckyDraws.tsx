import Box from '@mui/material/Box';
import React, {useEffect, useState} from 'react';
import AboutMichal from '../../shared/AboutMichal';
import { LuckyDrawDailyStats } from '../../models/LuckyDrawDailyStats';
import { LuckyDrawsPrizeHistogram } from '../../models/LuckyDrawsPrizeHistogram';
import { LuckyDrawsWinsHistogram } from '../../models/LuckyDrawsWinsHistogram';
import moment from 'moment';
import { getData } from '../../services/CsvUtils';
import { Grid } from '@mui/material';
import ChartContainer from '../../shared/ChartContainer';
import { Bar, BarChart, CartesianGrid, Line, LineChart, ResponsiveContainer, Tooltip, XAxis, YAxis } from 'recharts';
import { indigo, red } from '@mui/material/colors';

export default function LuckyDraws() {
    const [dailyStats, setDailyStats] = useState<LuckyDrawDailyStats[]>([]);
    const [prizeHistogram, setPrizeHistogram] = useState<LuckyDrawsPrizeHistogram[]>([]);
    const [earnersHistogram, setEarnersHistogram] = useState<LuckyDrawsWinsHistogram[]>([]);
    const dateFormatter = (date: Date) => moment(date).format('MMM Do');

    let USDollar = new Intl.NumberFormat('en-US', {
      style: 'currency',
      currency: 'USD',
    });

    useEffect(() => {
      const fetchDailyStatsData = async () => {
        const response = await getData<LuckyDrawDailyStats>("/data/LuckyDrawsDaily.csv");
        response.forEach(data => {
            data.DATE = new Date(data.DATE);
        });
        setDailyStats(response);
      };
      const fetchPrizeHistogramData = async () => {
        const response = await getData<LuckyDrawsPrizeHistogram>("/data/LuckyDrawsPrizeHistogram.csv");
        setPrizeHistogram(response);
      };
      const fetchEarnersHistogramData = async () => {
        const response = await getData<LuckyDrawsWinsHistogram>("/data/LuckyDrawsWinsHistogram.csv");
        setEarnersHistogram(response);
      };

      fetchPrizeHistogramData();
      fetchEarnersHistogramData();
      fetchDailyStatsData();
    }, []);


    return (
        <Grid container rowSpacing={3} columnSpacing={3}>
            <Grid item xs={12} >
              <AboutMichal />
            </Grid>
            <Grid item xl={6} xs={12} >
              <ChartContainer 
              chartId='daily-lucky-draw' 
              helpText='Chart represents number of Lucky Draws created in a given day. The spikes you can see are usualy related to some events (e.g. introducing new functionality, introducing new badge).'
              chartTitle='Daily number of Lucky Draws' 
              dataUrl='/data/LuckyDrawsDaily.csv'>
                <ResponsiveContainer width="100%" height={300}>
                  <LineChart data={dailyStats}>
                    <CartesianGrid strokeDasharray="3 3" />
                    <XAxis dataKey="DATE" scale="time" minTickGap={20} tickFormatter={dateFormatter}/>
                    <YAxis domain={['dataMin', 'auto']}/>    
                    <Tooltip labelFormatter={value => moment(value).format('DD-MM-YYYY')}/>
                    <Line type="monotone" dot={false} dataKey="DAILY_DRAWS" name='Daily Lucky Draws' strokeWidth={3} stroke={indigo[800]} />                  
                  </LineChart>
                </ResponsiveContainer>            
              </ChartContainer>
            </Grid>
            <Grid item xl={6} xs={12} >
              <ChartContainer 
              chartId='cumulative-lucky-draws' 
              chartTitle='Cumulative number of Lucky Draws' 
              helpText='Chart represents cumulative number of Lucky Draws (for the given day). This chart is up only and its quite linear (beside exponential beginning). It says that there is more or less similar interest in Lucky Draws over time'
              dataUrl='/data/LuckyDrawsDaily.csv'>
                <ResponsiveContainer width="100%" height={300}>
                  <LineChart data={dailyStats}>
                    <CartesianGrid strokeDasharray="3 3" />
                    <XAxis dataKey="DATE" scale="time" minTickGap={20} tickFormatter={dateFormatter}/>
                    <YAxis domain={['dataMin', 'auto']}/>    
                    <Tooltip labelFormatter={value => moment(value).format('DD-MM-YYYY')}/>
                    <Line type="monotone" dot={false} dataKey="TOTAL_DRAWS" name='Cumulative Lucky Draws' strokeWidth={3} stroke={red[800]} />                  
                  </LineChart>
                </ResponsiveContainer>           
              </ChartContainer>
            </Grid>
            <Grid item xl={6} xs={12} >
              <ChartContainer 
              chartId='daily-money-lucky-draws' 
              chartTitle='Daily money in Lucky Draws [$]' 
              helpText='Chart represents amount of money in all Lucky Draws for the given day. It is highly correlated  with Daily number of Lucky Draws.'
              dataUrl='/data/LuckyDrawsDaily.csv'>
                <ResponsiveContainer width="100%" height={300}>
                  <LineChart data={dailyStats}>
                    <CartesianGrid strokeDasharray="3 3" />
                    <XAxis dataKey="DATE" scale="time" minTickGap={20} tickFormatter={dateFormatter}/>
                    <YAxis domain={['dataMin', 'auto']}/>    
                    <Tooltip formatter={value => USDollar.format(Number(value.valueOf()))} labelFormatter={value => moment(value).format('DD-MM-YYYY')}/>
                    <Line type="monotone" dot={false} dataKey="DAILY_MONEY_IN_DRAWS" name='Daily $ in Lucky Draws' strokeWidth={3} stroke={indigo[800]} />                  
                  </LineChart>
                </ResponsiveContainer>         
              </ChartContainer>
            </Grid>
            <Grid item xl={6} xs={12} >
              <ChartContainer 
              chartId='cumulative-money-lucky-draws' 
              chartTitle='Cumulative money in Lucky Draws [$]' 
              helpText='Chart represents cumulative amount of money in all Lucky Draws created so far (for the given day). It is highly correlated with Cumulative number of Lucky Draws.'
              dataUrl='/data/LuckyDrawsDaily.csv'>
                <ResponsiveContainer width="100%" height={300}>
                  <LineChart data={dailyStats}>
                    <CartesianGrid strokeDasharray="3 3" />
                    <XAxis dataKey="DATE" scale="time" minTickGap={20} tickFormatter={dateFormatter}/>
                    <YAxis domain={['dataMin', 'auto']}/>    
                    <Tooltip formatter={value => USDollar.format(Number(value.valueOf()))} labelFormatter={value => moment(value).format('DD-MM-YYYY')}/>
                    <Line type="monotone" dot={false} dataKey="TOTAL_MONEY_IN_DRAWS" name='Cumulative $ in Lucky Draws' strokeWidth={3} stroke={red[800]} />                  
                  </LineChart>
                </ResponsiveContainer>     
              </ChartContainer>
            </Grid>
            <Grid item xl={6} xs={12} >
              <ChartContainer 
              chartId='lucky-draws-prize-histogram' 
              chartTitle='Rewards in Lucky Draws [$]' 
              helpText='Histogram represents total number of Lucky Draws for given prize range. Without any surprises most of the Lucky Draws are small, below $2.'
              dataUrl='/data/LuckyDrawsPrizeHistogram.csv'>
                <ResponsiveContainer width="100%" height={320}>
                  <BarChart layout='vertical' data={prizeHistogram}>
                    <CartesianGrid strokeDasharray="3 3" />
                    <XAxis type="number" />
                    <YAxis dataKey="LUCKY_DRAWS_PRIZE" type="category" />
                    <Tooltip />
                    <Bar dataKey="LUCKY_DRAWS_NUMBER" name='Number of Lucky Draws'  fill={indigo[800]} />
                  </BarChart>
                </ResponsiveContainer>     
              </ChartContainer>
            </Grid>
            <Grid item xl={6} xs={12} >
              <ChartContainer 
              chartId='lucky-draws-earners-histogram' 
              chartTitle='Total wins in Lucky Draws [$]' 
              helpText='Histogram represents total number of accounts that won Lucky Draw given number of times. '
              dataUrl='/data/LuckyDrawsWinsHistogram.csv'>
                <ResponsiveContainer width="100%" height={320}>
                  <BarChart layout='vertical' data={earnersHistogram}>
                    <CartesianGrid strokeDasharray="3 3" />
                    <XAxis type="number" />
                    <YAxis dataKey="NUMBER_OF_WINS" type="category" />
                    <Tooltip />
                    <Bar dataKey="NUMBER_OF_ACCOUNTS" name='Number of accounts'  fill={indigo[800]} />
                  </BarChart>
                </ResponsiveContainer>     
              </ChartContainer>
            </Grid>
        </Grid>
    );
  }