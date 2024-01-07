import React from 'react';
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import CardHeader from '@mui/material/CardHeader';
import Typography from '@mui/material/Typography';
import Button from '@mui/material/Button';
import Avatar from '@mui/material/Avatar';

export default function AboutNett() {
    return (
      <Card square elevation={0} sx={{backgroundColor: "grey.100", border:1, borderColor: 'grey.400' }} >
        <CardHeader
            avatar={<Avatar src="/Nett.png"/>}
            title="nett"
            titleTypographyProps={{variant:"h5"}}
        />
        <CardContent>
          <Typography variant="body2">
          Hi, I am nett! I am posting weekly changes in TOP 100 ranking. Here you can find raw data you can analyze yourself!
          </Typography>
        </CardContent>
        <CardActions>
          <Button target='_blank' href="https://debank.com/profile/0x78a18ddecda44f7d298d9b37512ed8a7f6b226c7/stream" sx={{borderRadius:0}} variant='outlined' size="small">DeBank Profile</Button>
          <Button target='_blank' href="https://github.com/forvard2" sx={{borderRadius:0}} variant='outlined' size="small">GitHub Profile</Button>
        </CardActions>
      </Card>
    );
  }