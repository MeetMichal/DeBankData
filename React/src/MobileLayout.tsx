import React, {useState} from 'react';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Drawer from '@mui/material/Drawer';
import IconButton from '@mui/material/IconButton';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import MenuIcon from '@mui/icons-material/Menu';

import './App.css';
import '@fontsource/roboto/300.css';
import '@fontsource/roboto/400.css';
import '@fontsource/roboto/500.css';
import '@fontsource/roboto/700.css';
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
