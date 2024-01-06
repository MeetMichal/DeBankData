import React, {useState} from 'react';
import { Route, Routes } from 'react-router-dom';
import DeBankUsers from './pages/michal/DeBankUsers';
import Top100Users from './pages/nett/Top100Users';
import RewardPools from './pages/michal/RewardPools';
import LuckyDraws from './pages/michal/LuckyDraws';
import StreamActivity from './pages/michal/StreamActivity';
import TopDepositors from './pages/michal/TopDepositors';
import Snapshots from './pages/debank/Snapshots';
import WelcomePage from './pages/WelcomePage';

const drawerWidth = 200;

export default function AppRoutes() {
  return (
    <Routes>
      <Route path="/michal/debank-users" element={<DeBankUsers />} />
      <Route path="/michal/reward-pools" element={<RewardPools />} />
      <Route path="/michal/lucky-draws" element={<LuckyDraws />} />
      <Route path="/michal/stream-activity" element={<StreamActivity />} />
      <Route path="/michal/top-depositors" element={<TopDepositors />} />
      <Route path="/nett/top-100" element={<Top100Users />} />
      <Route path="/debank/snapshot" element={<Snapshots />} />
      <Route path="/" element={<WelcomePage />} />

{/*       <Route path={`${process.env.PUBLIC_URL}/michal/debank-users`} element={<DeBankUsers />} />
      <Route path={`${process.env.PUBLIC_URL}/michal/reward-pools`} element={<RewardPools />} />
      <Route path={`${process.env.PUBLIC_URL}/michal/lucky-draws`} element={<LuckyDraws />} />
      <Route path={`${process.env.PUBLIC_URL}/michal/stream-activity`} element={<StreamActivity />} />
      <Route path={`${process.env.PUBLIC_URL}/michal/top-depositors`} element={<TopDepositors />} />
      <Route path={`${process.env.PUBLIC_URL}/nett/top-100`} element={<Top100Users />} />
      <Route path={`${process.env.PUBLIC_URL}/debank/snapshot`} element={<Snapshots />} />
      <Route path={`${process.env.PUBLIC_URL}/`} element={<WelcomePage />} /> */}
    </Routes>
  );
}