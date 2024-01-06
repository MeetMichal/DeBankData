import { Card, CardContent, CardHeader, Typography } from '@mui/material';
import React, {useState, useEffect} from 'react';


export default function Snapshots() {  
  return (
    <Card square elevation={0} sx={{backgroundColor: "grey.100", border:1, borderColor: 'grey.400' }} >
    <CardHeader
        title="Just Stats"
        titleTypographyProps={{variant:"h5"}}
    />
    <CardContent>
      <Typography variant="body2">
        Welcome to Just Stats! Use navigation menu to choose your favorite content creator.
        <br />
        Contant Michal on DeBank if you want to be featured here.
      </Typography>
    </CardContent>
  </Card>
  );
}