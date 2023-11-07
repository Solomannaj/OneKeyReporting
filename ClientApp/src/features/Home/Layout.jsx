import * as React from 'react';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import Menu from '@mui/material/Menu';
import { useSelector } from "react-redux";

export  function Layout() {

  const loginState = useSelector((state) => state.login);
  const { user,authenticated } = loginState;

  return (
    <Box sx={{ flexGrow: 1 }}>
      <AppBar  style={{ background: '#2E3B55' }} position="static">
        <Toolbar>
          <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
            Data Extraction Tool
          </Typography>
          {1 && (
            <div>
              <Menu
                id="menu-appbar"
                anchorOrigin={{
                  vertical: 'top',
                  horizontal: 'right',
                }}
                keepMounted
                transformOrigin={{
                  vertical: 'top',
                  horizontal: 'right',
                }}
              >
              </Menu>
            </div>
           
          )}
           <div>
              <Typography variant="h10" component="div" sx={{ flexGrow: 1 }}>
              {user.userName}
          </Typography>
            </div>
        </Toolbar>
      </AppBar>
    </Box>
  );
}