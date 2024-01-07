import React from 'react';
import Box from '@mui/material/Box';
import Drawer from '@mui/material/Drawer';
import AppBar from '@mui/material/AppBar';
import CssBaseline from '@mui/material/CssBaseline';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import Navigation from './Navigation';
import AppRoutes from './AppRoutes';

const drawerWidth = 200;

export default function DesktopLayout() {
  return (
    <Box sx={{ display: 'flex'}}>
      <CssBaseline />
      <AppBar position="fixed" sx={{ zIndex: (theme) => theme.zIndex.drawer + 1 }}>
        <Toolbar>
          <Typography variant="h6" noWrap component="div">
            Just Stats
          </Typography>
        </Toolbar>
      </AppBar>
      <Drawer
        PaperProps={{
          sx: {
            backgroundColor: "grey.50",
          }
        }}
        variant="permanent"
        sx={{
          width: drawerWidth,
          flexShrink: 0,
          [`& .MuiDrawer-paper`]: { width: drawerWidth, boxSizing: 'border-box' },
        }}
      >
        <Toolbar />
        <Box sx={{ overflow: 'auto' }}>
          <Navigation />
        </Box>
      </Drawer>
      <Box component="main" sx={{ flexGrow: 1, p: 4, marginTop:8}}>
        <AppRoutes />
      </Box>
    </Box>
  );
}