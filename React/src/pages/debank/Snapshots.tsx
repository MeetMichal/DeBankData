import React, {useState, useEffect} from 'react';
import AboutNett from '../../shared/AboutNett';
import { Box, Button, Grid, Typography } from '@mui/material';
import {getData} from "../../services/CsvUtils"
import {UserRank} from "../../models/UserRank"
import { DataGrid, GridColDef } from '@mui/x-data-grid';
import DownlaodIcon from '@mui/icons-material/FileDownload';
import { useTheme } from "@mui/material/styles";
import useMediaQuery from "@mui/material/useMediaQuery";
import AboutDeBank from '../../shared/AboutDeBank';

export default function Snapshots() {
  const theme = useTheme();
  const isDesktop = useMediaQuery(theme.breakpoints.up('sm'));
  
  return (
    <Grid container rowSpacing={3} columnSpacing={3}>
      <Grid item xs={12} >
        <AboutDeBank />
      </Grid>
    </Grid>
  );
}