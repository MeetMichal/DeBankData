import React, {useEffect, useState} from 'react';
import AboutMichal from '../../shared/AboutMichal';
import { Grid } from '@mui/material';
import ChartContainer from '../../shared/ChartContainer';
import { CartesianGrid, Line, LineChart, ResponsiveContainer, Tooltip, XAxis, YAxis } from 'recharts';
import moment from 'moment';
import { UserRegistration } from '../../models/UserRegistration';
import { getData } from '../../services/CsvUtils';
import { OfficialAccountsRegistration } from '../../models/OfficialAccountsRegistration';
import { indigo } from '@mui/material/colors';

export default function DeBankUsers() {
    const [userStats, setUserStats] = useState<UserRegistration[]>([]);
    const [officialProfilesStats, setOfficialProfilesStats] = useState<OfficialAccountsRegistration[]>([]);
    const dateFormatter = (date: Date) => moment(date).format('MMM Do');
    const omitNFirst = 38; //Hack to properly display XAxis
    useEffect(() => {
        const fetchUsersStatsData = async () => {
            const response = await getData<UserRegistration>("/data/UserRegistrations.csv");
            response.forEach(data => {
                data.DATE = new Date(data.DATE);
                data.DATE_NUMBER = moment(data.DATE).valueOf()
            });
            setUserStats(response);
        };
        const fetchOfficialProfilesStatsData = async () => {
            const response = await getData<OfficialAccountsRegistration>("/data/OfficialProfilesRegistrations.csv");
            response.forEach(data => {
                data.DATE = new Date(data.DATE);
            });
            setOfficialProfilesStats(response);
        };

        fetchOfficialProfilesStatsData();
        fetchUsersStatsData();
      }, []);

    return (
        <Grid container rowSpacing={3} columnSpacing={3}>
            <Grid item xs={12} >
              <AboutMichal />
            </Grid>
            <Grid item xl={6} xs={12} >
              <ChartContainer 
              chartId='web3id-minters' 
              helpText='Chart represents cumulative number of WEB3 IDs minted (for a given day).'
              chartTitle='Web3 ID minters' 
              dataUrl='/data/UserRegistrations.csv'>
                <ResponsiveContainer width="100%" height={300}>
                  <LineChart data={userStats.slice(omitNFirst)}>
                    <CartesianGrid strokeDasharray="3 3" />
                    <XAxis dataKey="DATE" scale="time" minTickGap={20} tickFormatter={dateFormatter}/>
                    <YAxis domain={['dataMin', 'auto']}/>    
                    <Tooltip labelFormatter={value => moment(value).format('DD-MM-YYYY')}/>
                    <Line type="monotone" connectNulls dot={false} dataKey="WEB3ID_MINTERS" name='Web3 ID minters' strokeWidth={3} stroke={indigo[800]} />                  
                  </LineChart>
                </ResponsiveContainer>            
              </ChartContainer>
            </Grid>
            <Grid item xl={6} xs={12} >
              <ChartContainer 
              chartId='l2-registrations' 
              chartTitle='DeBank L2 registrations' 
              helpText='Chart represents cumulative number of L2 registrations (for the given day). Data taken from: https://dune.com/Nett/debank-registers'
              dataUrl='/data/UserRegistrations.csv'>
                <ResponsiveContainer width="100%" height={300}>
                  <LineChart data={userStats}>
                    <CartesianGrid strokeDasharray="3 3" />
                    <XAxis dataKey="DATE" scale="time" minTickGap={20} tickFormatter={dateFormatter}/>
                    <YAxis domain={['dataMin', 'auto']}/>    
                    <Tooltip labelFormatter={value => moment(value).format('DD-MM-YYYY')}/>
                    <Line type="monotone" dot={false} dataKey="L2_REGISTRATIONS" name='L2 registrations' strokeWidth={3} stroke={indigo[800]} />                  
                  </LineChart>
                </ResponsiveContainer>           
              </ChartContainer>
            </Grid>
            <Grid item xl={6} xs={12} >
              <ChartContainer 
              chartId='official-profiles-registrations' 
              chartTitle='Official Profiles registrations' 
              helpText='Chart represents cumulative number of Official Profiles registrations (for the given day).'
              dataUrl='/data/OfficialProfilesRegistrations.csv'>
                <ResponsiveContainer width="100%" height={300}>
                  <LineChart data={officialProfilesStats}>
                    <CartesianGrid strokeDasharray="3 3" />
                    <XAxis dataKey="DATE" scale="time" minTickGap={20} tickFormatter={dateFormatter}/>
                    <YAxis domain={['dataMin', 'auto']}/>    
                    <Tooltip labelFormatter={value => moment(value).format('DD-MM-YYYY')}/>
                    <Line type="monotone" dot={false} dataKey="NUMBER_OF_OFFICIAL_ACCOUNTS" name='Official profiles' strokeWidth={3} stroke={indigo[800]} />                  
                  </LineChart>
                </ResponsiveContainer>           
              </ChartContainer>
            </Grid>
        </Grid>
    );
  }