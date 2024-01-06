import React, {useState} from 'react';
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
            avatar={<Avatar src="/Debank.png"/>}
            title="DeBank"
            titleTypographyProps={{variant:"h5"}}
        />
        <CardContent>
          <Typography variant="body2">
            All snapshot data are available under link: <a>https://github.com/DeBankDeFi/web3-data</a>
          </Typography>
        </CardContent>
        <CardActions>
          <Button target='_blank' href="https://github.com/DeBankDeFi" sx={{borderRadius:0}} variant='outlined' size="small">GitHub Profile</Button>
        </CardActions>
      </Card>
    );
  }