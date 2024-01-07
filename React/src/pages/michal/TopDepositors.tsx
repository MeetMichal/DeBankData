import Box from '@mui/material/Box';
import React, {useEffect, useState} from 'react';
import AboutMichal from '../../shared/AboutMichal';
import { Button, Grid, Typography, useMediaQuery, useTheme } from '@mui/material';
import { DataGrid, GridColDef } from '@mui/x-data-grid';
import { getData } from '../../services/CsvUtils';
import DownlaodIcon from '@mui/icons-material/FileDownload';
import { UserSpendings } from '../../models/UserSpendings';

export default function TopDepositors() {
    const [rpDepositors, setRpDepositors] = useState<UserSpendings[]>([]);
    const [ldDepositors, setLdDepositors] = useState<UserSpendings[]>([]);

    const theme = useTheme();
    const isDesktop = useMediaQuery(theme.breakpoints.up('sm'));
    
    let USDollar = new Intl.NumberFormat('en-US', {
        style: 'currency',
        currency: 'USD',
      });
      const columns: GridColDef[] = [
        { field: 'WEB3_ID', headerName: 'Web3 ID', flex:1},
        { 
          field: 'TOTAL_DEPOSIT', 
          headerName: 'Total deposit', 
          flex:1,
          valueFormatter: params => USDollar.format(params.value)
        },
        { 
            field: 'MIN_DEPOSIT', 
            headerName: 'Min deposit', 
            flex:1,
            valueFormatter: params => USDollar.format(params.value)
        },
        { 
            field: 'MAX_DEPOSIT', 
            headerName: 'Max deposit', 
            flex:1,
            valueFormatter: params => USDollar.format(params.value)
        },
        { 
            field: 'AVERAGE_DEPOSIT', 
            headerName: 'Average deposit', 
            flex:1,
            valueFormatter: params => USDollar.format(params.value)
        },
        { 
            field: 'NUMBER_OF_DEPOSITS', 
            headerName: 'Number of deposits', 
            flex:1,
        },
      ];
    
      useEffect(() => {
        const fetchRpData = async () => {
          const response = await getData<UserSpendings>("/data/RewardPoolsSpenders.csv")
          setRpDepositors(response);
        };
        const fetchLdData = async () => {
            const response = await getData<UserSpendings>("/data/LuckyDrawsSpenders.csv")
            setLdDepositors(response);
          };

        fetchLdData();
        fetchRpData();
      }, []);

    return (
        <Grid container rowSpacing={3} columnSpacing={3}>
            <Grid item xs={12} >
                <AboutMichal />
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
                        Top 10 Reward Pools depositors
                    </Typography>
                    <DataGrid
                        sx={{
                        backgroundColor: "grey.100",
                        border: 1,
                        borderRadius:0,
                        borderColor: 'grey.400'
                        }}
                        disableRowSelectionOnClick
                        columns={columns}
                        rows={rpDepositors}
                        getRowId={(row) => row.WEB3_ID}
                        initialState={{
                        pagination: {
                            paginationModel: { page: 0, pageSize: 25 },
                        },
                        columns: {
                            columnVisibilityModel: {
                                MIN_DEPOSIT: isDesktop,
                                MAX_DEPOSIT: isDesktop,
                                AVERAGE_DEPOSIT: isDesktop
                            },
                        },
                        }}
                        pageSizeOptions={[10, 25, 50, 100]}
                    />    
                    {isDesktop?
                        <Box                    
                        sx={{
                        p:1,
                        backgroundColor: "grey.100",
                        border: 1,
                        borderTop:0,
                        borderRadius:0,
                        borderColor: 'grey.400'
                        }}>
                        <Button href='/data/RewardPoolsSpenders.csv' target="_blank" startIcon={<DownlaodIcon/>} sx={{borderRadius:0}} variant='outlined' size="small">
                        GET DATA
                        </Button>
                    </Box> 
                    :null            
                    }
                </Box>
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
                        Top 10 Lucky Draws depositors
                    </Typography>
                    <DataGrid
                        sx={{
                        backgroundColor: "grey.100",
                        border: 1,
                        borderRadius:0,
                        borderColor: 'grey.400'
                        }}
                        disableRowSelectionOnClick
                        columns={columns}
                        rows={ldDepositors}
                        getRowId={(row) => row.WEB3_ID}
                        initialState={{
                        pagination: {
                            paginationModel: { page: 0, pageSize: 25 },
                        },
                        columns: {
                            columnVisibilityModel: {
                                MIN_DEPOSIT: isDesktop,
                                MAX_DEPOSIT: isDesktop,
                                AVERAGE_DEPOSIT: isDesktop
                            },
                        },
                        }}
                        pageSizeOptions={[10, 25, 50, 100]}
                    />    
                    {isDesktop?
                        <Box                    
                        sx={{
                        p:1,
                        backgroundColor: "grey.100",
                        border: 1,
                        borderTop:0,
                        borderRadius:0,
                        borderColor: 'grey.400'
                        }}>
                        <Button href='/data/LuckyDrawsSpenders.csv' target="_blank" startIcon={<DownlaodIcon/>} sx={{borderRadius:0}} variant='outlined' size="small">
                            GET DATA
                        </Button>
                    </Box> 
                    :null            
                    }
                </Box>
            </Grid>
        </Grid>
      );
  }