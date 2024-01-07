import React, {useState, useEffect} from 'react';
import { RewardPoolDailyStats } from '../../models/RewardPoolDailyStats';
import { RewardPoolsPrizeHistogram } from '../../models/RewardPoolsPrizeHistogram';
import { RewardPoolsEarnersHistogram } from '../../models/RewardPoolsEarnersHistogram';
import AboutMichal from '../../shared/AboutMichal';
import { getData } from '../../services/CsvUtils';
import { Grid } from '@mui/material';
import {indigo, red} from '@mui/material/colors'
import { Bar, BarChart, CartesianGrid, Line, LineChart, ResponsiveContainer, Tooltip, XAxis, YAxis } from 'recharts';
import moment from 'moment';
import ChartContainer from '../../shared/ChartContainer';

export default function RewardPools() {
    const [dailyStats, setDailyStats] = useState<RewardPoolDailyStats[]>([]);
    const [prizeHistogram, setPrizeHistogram] = useState<RewardPoolsPrizeHistogram[]>([]);
    const [earnersHistogram, setEarnersHistogram] = useState<RewardPoolsEarnersHistogram[]>([]);
    const dateFormatter = (date: Date) => moment(date).format('MMM Do');

    let USDollar = new Intl.NumberFormat('en-US', {
      style: 'currency',
      currency: 'USD',
    });

    useEffect(() => {
      const fetchDailyStatsData = async () => {
        const response = await getData<RewardPoolDailyStats>("/data/RewardPoolsDaily.csv");
        response.forEach(data => {
            data.DATE = new Date(data.DATE);
        });
        setDailyStats(response);
      };
      const fetchPrizeHistogramData = async () => {
        const response = await getData<RewardPoolsPrizeHistogram>("/data/RewardPoolsPrizeHistogram.csv");
        setPrizeHistogram(response);
      };
      const fetchEarnersHistogramData = async () => {
        const response = await getData<RewardPoolsEarnersHistogram>("/data/RewardPoolsEarningsHistogram.csv");
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
              chartId='daily-reward-pools' 
              helpText='Chart represents number of Reward Pools created in a given day. The spikes you can see are usualy related to some events (e.g. introducing new functionality).'
              chartTitle='Daily number of Reward Pools' 
              dataUrl='/data/RewardPoolsDaily.csv'>
                <ResponsiveContainer width="100%" height={300}>
                  <LineChart data={dailyStats}>
                    <CartesianGrid strokeDasharray="3 3" />
                    <XAxis dataKey="DATE" scale="time" minTickGap={20} tickFormatter={dateFormatter}/>
                    <YAxis domain={['dataMin', 'auto']}/>    
                    <Tooltip labelFormatter={value => moment(value).format('DD-MM-YYYY')}/>
                    <Line type="monotone" dot={false} dataKey="DAILY_REWARDPOOLS" name='Daily Reward Pools' strokeWidth={3} stroke={indigo[800]} />                  
                  </LineChart>
                </ResponsiveContainer>            
              </ChartContainer>
            </Grid>
            <Grid item xl={6} xs={12} >
              <ChartContainer 
              chartId='cumulative-reward-pools' 
              chartTitle='Cumulative number of Reward Pools' 
              helpText='Chart represents cumulative number of Reward Pools created so far (for the given day). This chart is up only. Sometimes its flat and sometimes its sharp, depending on the interests in Reward Pools'
              dataUrl='/data/RewardPoolsDaily.csv'>
                <ResponsiveContainer width="100%" height={300}>
                  <LineChart data={dailyStats}>
                    <CartesianGrid strokeDasharray="3 3" />
                    <XAxis dataKey="DATE" scale="time" minTickGap={20} tickFormatter={dateFormatter}/>
                    <YAxis domain={['dataMin', 'auto']}/>    
                    <Tooltip labelFormatter={value => moment(value).format('DD-MM-YYYY')}/>
                    <Line type="monotone" dot={false} dataKey="TOTAL_REWARDPOOLS" name='Cumulative Reward Pools' strokeWidth={3} stroke={red[800]} />                  
                  </LineChart>
                </ResponsiveContainer>           
              </ChartContainer>
            </Grid>
            <Grid item xl={6} xs={12} >
              <ChartContainer 
              chartId='daily-money-reward-pools' 
              chartTitle='Daily money in Reward Pools [$]' 
              helpText='Chart represents amount of money in all Reward Pools for the given day. It is highly correlated  with Daily number of Reward Pools.'
              dataUrl='/data/RewardPoolsDaily.csv'>
                <ResponsiveContainer width="100%" height={300}>
                  <LineChart data={dailyStats}>
                    <CartesianGrid strokeDasharray="3 3" />
                    <XAxis dataKey="DATE" scale="time" minTickGap={20} tickFormatter={dateFormatter}/>
                    <YAxis domain={['dataMin', 'auto']}/>    
                    <Tooltip formatter={value => USDollar.format(Number(value.valueOf()))} labelFormatter={value => moment(value).format('DD-MM-YYYY')}/>
                    <Line type="monotone" dot={false} dataKey="DAILY_MONEY_IN_REWARDPOOLS" name='Daily $ in Reward Pools' strokeWidth={3} stroke={indigo[800]} />                  
                  </LineChart>
                </ResponsiveContainer>         
              </ChartContainer>
            </Grid>
            <Grid item xl={6} xs={12} >
              <ChartContainer 
              chartId='cumulative-money-reward-pools' 
              chartTitle='Cumulative money in Reward Pools [$]' 
              helpText='Chart represents cumulative amount of money in all Reward Pools created so far (for the given day). It is highly correlated with Cumulative number of Reward Pools.'
              dataUrl='/data/RewardPoolsDaily.csv'>
                <ResponsiveContainer width="100%" height={300}>
                  <LineChart data={dailyStats}>
                    <CartesianGrid strokeDasharray="3 3" />
                    <XAxis dataKey="DATE" scale="time" minTickGap={20} tickFormatter={dateFormatter}/>
                    <YAxis domain={['dataMin', 'auto']}/>    
                    <Tooltip formatter={value => USDollar.format(Number(value.valueOf()))} labelFormatter={value => moment(value).format('DD-MM-YYYY')}/>
                    <Line type="monotone" dot={false} dataKey="TOTAL_MONEY_IN_REWARDPOOLS" name='Cumulative $ in Reward Pools' strokeWidth={3} stroke={red[800]} />                  
                  </LineChart>
                </ResponsiveContainer>     
              </ChartContainer>
            </Grid>
            <Grid item xl={6} xs={12} >
              <ChartContainer 
              chartId='reward-pools-prize-histogram' 
              chartTitle='Rewards in Reward Pools [$]' 
              helpText='Histogram represents total number of Reward Pools for given prize range. Without any surprises most of the Reward Pools are small, below $1.'
              dataUrl='/data/RewardPoolsPrizeHistogram.csv'>
                <ResponsiveContainer width="100%" height={340}>
                  <BarChart layout='vertical' data={prizeHistogram}>
                    <CartesianGrid strokeDasharray="3 3" />
                    <XAxis type="number" />
                    <YAxis dataKey="REWARD_POOL_PRIZE" type="category" />
                    <Tooltip />
                    <Bar dataKey="REWARD_POOLS_NUMBER" name='Number of Reward Pools'  fill={indigo[800]} />
                  </BarChart>
                </ResponsiveContainer>     
              </ChartContainer>
            </Grid>
            <Grid item xl={6} xs={12} >
              <ChartContainer 
              chartId='reward-pools-earners-histogram' 
              chartTitle='Total earnings from Reward Pools [$]' 
              helpText='Histogram represents total earnings from Reward Pools. Unfortunately it might not be accurate since DeBank doesnt disclose full information about Reward Pool earners. Please pay attention that only fraction of users are earning any meaningful amount. There is enormous number of accounts with total earnings less than $0.5'
              dataUrl='/data/RewardPoolsEarningsHistogram.csv'>
                <ResponsiveContainer width="100%" height={340}>
                  <BarChart layout='vertical' data={earnersHistogram}>
                    <CartesianGrid strokeDasharray="3 3" />
                    <XAxis type="number" />
                    <YAxis dataKey="REWARD_POOL_EARNING" width={80} type="category" />
                    <Tooltip />
                    <Bar dataKey="EARNERS_NUMBER" name='Number of accounts with given earnings'  fill={indigo[800]} />
                  </BarChart>
                </ResponsiveContainer>     
              </ChartContainer>
            </Grid>
        </Grid>
    );
  }