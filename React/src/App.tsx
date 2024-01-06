import React, {useState} from 'react';
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
import DesktopLayout from './DesktopLayout';
import MobileLayout from './MobileLayout';

function App() {
  const theme = useTheme();
  const isDesktop = useMediaQuery(theme.breakpoints.up('sm'));

  return isDesktop ? <DesktopLayout /> : <MobileLayout />
}

export default App;
