import React from 'react';
import { Grid } from '@mui/material';
import AboutDeBank from '../../shared/AboutDeBank';

export default function Snapshots() {
  
  return (
    <Grid container rowSpacing={3} columnSpacing={3}>
      <Grid item xs={12} >
        <AboutDeBank />
      </Grid>
      <Grid item xs={12} >
        Charts will be available in coming days
      </Grid>
    </Grid>
  );
}