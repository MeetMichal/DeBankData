import Box from '@mui/material/Box';
import React, {useEffect, useState} from 'react';
import AboutMichal from '../../shared/AboutMichal';
import { StreamActivityDailyStats } from '../../models/StreamActivityDailyStats';
import { StreamActivityHistogram } from '../../models/StreamActivityHistogram';
import moment from 'moment';
import { getData } from '../../services/CsvUtils';
import { Grid } from '@mui/material';
import ChartContainer from '../../shared/ChartContainer';
import { Bar, BarChart, CartesianGrid, Line, LineChart, ResponsiveContainer, Tooltip, XAxis, YAxis } from 'recharts';
import { indigo, red } from '@mui/material/colors';

export default function StreamActivity() {
    const [dailyStats, setDailyStats] = useState<StreamActivityDailyStats[]>([]);
    const [histogram, setHistogram] = useState<StreamActivityHistogram[]>([]);
    const dateFormatter = (date: Date) => moment(date).format('MMM Do');

    useEffect(() => {
      const fetchDailyStatsData = async () => {
        const response = await getData<StreamActivityDailyStats>("/data/StreamActivity.csv");
        response.forEach(data => {
            data.DATE = new Date(data.DATE);
        });
        setDailyStats(response);
      };
      const fetchHistogramData = async () => {
        const response = await getData<StreamActivityHistogram>("/data/StreamActivityHistogram.csv");
        setHistogram(response);
      };
      
      fetchHistogramData();
      fetchDailyStatsData();
    }, []);


    return (
        <Grid container rowSpacing={3} columnSpacing={3}>
            <Grid item xs={12} >
              <AboutMichal />
            </Grid>
            <Grid item xl={6} xs={12} >
              <ChartContainer 
              chartId='daily-stream-activity' 
              helpText='Chart represents number of Posts created in a given day. The spikes you can see are usualy related to some events (e.g. introducing new functionality, introducing new badge).'
              chartTitle='Daily number of Posts' 
              dataUrl='/data/StreamActivity.csv'>
                <ResponsiveContainer width="100%" height={300}>
                  <LineChart data={dailyStats}>
                    <CartesianGrid strokeDasharray="3 3" />
                    <XAxis dataKey="DATE" scale="time" minTickGap={20} tickFormatter={dateFormatter}/>
                    <YAxis domain={['dataMin', 'auto']}/>    
                    <Tooltip labelFormatter={value => moment(value).format('DD-MM-YYYY')}/>
                    <Line type="monotone" dot={false} dataKey="DAILY_ARTICLES" name='Daily Lucky Draws' strokeWidth={3} stroke={indigo[800]} />                  
                  </LineChart>
                </ResponsiveContainer>            
              </ChartContainer>
            </Grid>
            <Grid item xl={6} xs={12} >
              <ChartContainer 
              chartId='cumulative-stream-activity' 
              chartTitle='Cumulative number of Posts' 
              helpText='Chart represents cumulative number of Posts (for the given day). This chart is up only.'
              dataUrl='/data/StreamActivity.csv'>
                <ResponsiveContainer width="100%" height={300}>
                  <LineChart data={dailyStats}>
                    <CartesianGrid strokeDasharray="3 3" />
                    <XAxis dataKey="DATE" scale="time" minTickGap={20} tickFormatter={dateFormatter}/>
                    <YAxis domain={['dataMin', 'auto']}/>    
                    <Tooltip labelFormatter={value => moment(value).format('DD-MM-YYYY')}/>
                    <Line type="monotone" dot={false} dataKey="TOTAL_ARTICLES" name='Cumulative Posts' strokeWidth={3} stroke={red[800]} />                  
                  </LineChart>
                </ResponsiveContainer>           
              </ChartContainer>
            </Grid>
            <Grid item xl={6} xs={12} >
              <ChartContainer 
              chartId='daily-unique-users' 
              chartTitle='Daily number of unique authors' 
              helpText='Chart represents number of unique authors posting in a given day. It is highly correlated with Daily number of Posts.'
              dataUrl='/data/StreamActivity.csv'>
                <ResponsiveContainer width="100%" height={300}>
                  <LineChart data={dailyStats}>
                    <CartesianGrid strokeDasharray="3 3" />
                    <XAxis dataKey="DATE" scale="time" minTickGap={20} tickFormatter={dateFormatter}/>
                    <YAxis domain={['dataMin', 'auto']}/>    
                    <Tooltip labelFormatter={value => moment(value).format('DD-MM-YYYY')}/>
                    <Line type="monotone" dot={false} dataKey="DAILY_UNIQUE_USERS" name='Daily unique authors' strokeWidth={3} stroke={indigo[800]} />                  
                  </LineChart>
                </ResponsiveContainer>         
              </ChartContainer>
            </Grid>
            <Grid item xl={6} xs={12} >
              <ChartContainer 
              chartId='total-unique-users' 
              chartTitle='Cumulative number of unique auhors' 
              helpText='Chart represents cumulative number of unique authors posting so far (for the given day). It is highly correlated with Cumulative number of Posts.'
              dataUrl='/data/StreamActivity.csv'>
                <ResponsiveContainer width="100%" height={300}>
                  <LineChart data={dailyStats}>
                    <CartesianGrid strokeDasharray="3 3" />
                    <XAxis dataKey="DATE" scale="time" minTickGap={20} tickFormatter={dateFormatter}/>
                    <YAxis domain={['dataMin', 'auto']}/>    
                    <Tooltip labelFormatter={value => moment(value).format('DD-MM-YYYY')}/>
                    <Line type="monotone" dot={false} dataKey="TOTAL_UNIQUE_USERS" name='Cumulative unique authors' strokeWidth={3} stroke={red[800]} />                  
                  </LineChart>
                </ResponsiveContainer>     
              </ChartContainer>
            </Grid>
            <Grid item xl={6} xs={12} >
              <ChartContainer 
              chartId='stream-activity-histogram' 
              chartTitle='Number of posts' 
              helpText='Histogram represents total number of accounts that posted given number of posts.'
              dataUrl='/data/StreamActivityHistogram.csv'>
                <ResponsiveContainer width="100%" height={320}>
                  <BarChart layout='vertical' data={histogram}>
                    <CartesianGrid strokeDasharray="3 3" />
                    <XAxis type="number" />
                    <YAxis dataKey="NUMBER_OF_POSTS" type="category" />
                    <Tooltip />
                    <Bar dataKey="AUTHORS_AMOUNT" name='Number authors'  fill={indigo[800]} />
                  </BarChart>
                </ResponsiveContainer>     
              </ChartContainer>
            </Grid>
        </Grid>
    );
  }