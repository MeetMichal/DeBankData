import React from 'react';
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import CardHeader from '@mui/material/CardHeader';
import Typography from '@mui/material/Typography';
import Button from '@mui/material/Button';
import Avatar from '@mui/material/Avatar';

export default function AboutMichal() {
    return (
      <Card square elevation={0} sx={{backgroundColor: "grey.100", border:1, borderColor: 'grey.400' }} >
        <CardHeader
            avatar={<Avatar src="/Michal.png"/>}
            title="Michal"
            titleTypographyProps={{variant:"h5"}}
        />
        <CardContent>
          <Typography variant="body2">
          Hi, I am Michal! Good to see you there. I hope you like charts and statistics because thats the only thing you can find here. I built this for you so feel free to give me your feedback. You can always DM me or just ping under any of my posts on DeBank
          </Typography>
        </CardContent>
        <CardActions>
          <Button target='_blank' href="https://debank.com/profile/0x33c36dd8ee2fc8b8c106e700f093c7b971eb8a70/stream" sx={{borderRadius:0}} variant='outlined' size="small">DeBank Profile</Button>
          <Button target='_blank' href="https://github.com/MeetMichal" sx={{borderRadius:0}} variant='outlined' size="small">GitHub Profile</Button>
        </CardActions>
      </Card>
    );
  }