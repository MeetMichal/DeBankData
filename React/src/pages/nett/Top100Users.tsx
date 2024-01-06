import React, {useState, useEffect} from 'react';
import AboutNett from '../../shared/AboutNett';
import { Box, Button, Grid, Typography } from '@mui/material';
import {getData} from "../../services/CsvUtils"
import {UserRank} from "../../models/UserRank"
import { DataGrid, GridColDef } from '@mui/x-data-grid';
import DownlaodIcon from '@mui/icons-material/FileDownload';
import { useTheme } from "@mui/material/styles";
import useMediaQuery from "@mui/material/useMediaQuery";
import { LineChart, Line,CartesianGrid, ResponsiveContainer, Scatter, ScatterChart, Tooltip, XAxis, YAxis } from 'recharts';

export default function Top100Users() {
  const [usersRank, setUsersRank] = useState<UserRank[]>([]);
  const theme = useTheme();
  const isDesktop = useMediaQuery(theme.breakpoints.up('sm'));

  let USDollar = new Intl.NumberFormat('en-US', {
    style: 'currency',
    currency: 'USD',
  });

  const columns: GridColDef[] = [
    { field: 'rank', headerName: 'Rank', flex:1},
    { field: 'web3_id', headerName: 'Web3 ID', flex:1},
    { 
      field: 'balance', 
      headerName: 'Balance', 
      flex:1,
      valueFormatter: params => USDollar.format(params.value)
    },
    { field: 'followers', headerName: 'Followers', flex:1},
    { field: 'trust', headerName: 'Trusts', flex:1},
    { 
      field: 'contribution', 
      headerName: 'Contribution', 
      flex:1,
      valueFormatter: params => USDollar.format(params.value)
    },
  ];

  useEffect(() => {
    const fetchData = async () => {
      const response = await getData<UserRank>("/data/top100.csv")
      setUsersRank(response);
    };

    fetchData();
  }, []);
  
  return (
    <Grid container rowSpacing={3} columnSpacing={3}>
      <Grid item xs={12} >
        <AboutNett />
      </Grid>
      <Grid item xs={12} >
        <Box>
          <Typography 
            sx={{
              p: 2,
              textAlign: "center",
              backgroundColor: "grey.100",
              border:1, 
              borderBottom:0,
              borderRadius:0,
              borderColor: 'grey.400'
            }} 
            variant={isDesktop ? "h5" : "body1"}>
            Top 100 users
          </Typography>
          <DataGrid
            sx={{
              backgroundColor: "grey.100",
              border: 1,
              borderRadius:0,
              borderColor: 'grey.400'
            }}
            columns={columns}
            rows={usersRank}
            initialState={{
              pagination: {
                paginationModel: { page: 0, pageSize: 25 },
              },
              columns: {
                columnVisibilityModel: {
                  rank: isDesktop,
                  balance: isDesktop,
                  contribution: isDesktop
                },
              },
            }}
            pageSizeOptions={[10, 25, 50, 100]}
          />    
          <Box                    
            sx={{
              p:1,
              backgroundColor: "grey.100",
              border: 1,
              borderTop:0,
              borderRadius:0,
              borderColor: 'grey.400'
            }}>
            <Button href='/data/top100.csv' target="_blank" startIcon={<DownlaodIcon/>} sx={{borderRadius:0}} variant='outlined' size="small">
              GET DATA
            </Button>
          </Box>      
        </Box>
      </Grid>
{/*       <Grid item xs={12} >
        <Box 
          sx={{
              backgroundColor: "grey.100",
              border:1, 
              borderRadius:0,
              borderColor: 'grey.400'
          }} 
        >
          <Typography 
            sx={{
              p: 2,
              textAlign: "center",
            }} 
            variant="h5">
            Balance vs Trusts chart
          </Typography>    
          <ResponsiveContainer width="100%" height={400}>
            <ScatterChart>
              <CartesianGrid />
              <XAxis type="number" dataKey="balance" name="Balance" unit="$" />
              <YAxis type="number" dataKey="trust" name="Trusts" />
              <Tooltip cursor={{ strokeDasharray: '3 3' }} />
              <Scatter name="TOP 100 users" data={usersRank} fill="#8884d8" />
            </ScatterChart>
          </ResponsiveContainer>
        </Box>
      </Grid> */}
    </Grid>
  );
}