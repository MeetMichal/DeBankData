import React, {useState} from 'react';
import logo from './logo.svg';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Drawer from '@mui/material/Drawer';
import SvgIcon from '@mui/material/SvgIcon';
import IconButton from '@mui/material/IconButton';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import Collapse from '@mui/material/Collapse';
import ExpandLess from '@mui/icons-material/ExpandLess';
import ExpandMore from '@mui/icons-material/ExpandMore';
import InboxIcon from '@mui/icons-material/MoveToInbox';
import MenuIcon from '@mui/icons-material/Menu';
import { styled, useTheme } from '@mui/material/styles';
import useMediaQuery from '@mui/material/useMediaQuery';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';

import './App.css';
import '@fontsource/roboto/300.css';
import '@fontsource/roboto/400.css';
import '@fontsource/roboto/500.css';
import '@fontsource/roboto/700.css';
import DeBankUsers from './pages/michal/DeBankUsers';
import Top100Users from './pages/nett/Top100Users';
import Navigation from './Navigation';
import AppRoutes from './AppRoutes';

function App() {
  const [isDrawerOpen, setIsDrawerOpen] = useState(false);

  const toggleDrawer = () => {
    setIsDrawerOpen(!isDrawerOpen);
  };

  return (
    <Box sx={{display:"flex"}}>
      <AppBar sx={{ zIndex: (theme) => theme.zIndex.drawer + 1 }}>
        <Toolbar>
          <IconButton
                onClick={toggleDrawer}
                color="inherit"
                aria-label="Open menu"
                edge="start"
                sx={{
                  marginRight: 5,
                }}
              >
                <MenuIcon />
          </IconButton>
          <Typography variant="h6" noWrap component="div">
            Just Stats
          </Typography>
        </Toolbar>
      </AppBar>
      <Drawer 
        sx={{display: isDrawerOpen ? "inherit" : "none", flexShrink:0}}
        anchor='bottom'
        open={isDrawerOpen}
        PaperProps={{sx: {width: "100%"}}}> 
        <Navigation />
      </Drawer>
      <Box  
        sx={{
          marginTop:8,   
          flexGrow: 1,
          padding: theme => theme.spacing(1),
        }}
      >
        <AppRoutes />
      </Box>
    </Box>
  );
}

export default App;
