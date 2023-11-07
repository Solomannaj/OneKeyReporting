import Button from "@mui/material/Button";
import TextField from "@mui/material/TextField";
import FormControlLabel from "@mui/material/FormControlLabel";
import Checkbox from "@mui/material/Checkbox";
import Box from "@mui/material/Box";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import React, { useState, useEffect }  from 'react';
import { useHistory } from "react-router-dom";
import { useSelector, useDispatch } from "react-redux";
import Alert from '@mui/material/Alert';
import {
    login,
    
  } from "./loginSlice";

export default function Login() {

    const history = useHistory();
    const dispatch = useDispatch();
    const loginState = useSelector((state) => state.login);
    const { user,authenticated } = loginState;

    const [showWarning, setShowWarning] = useState(false);

    useEffect(() => {
        if(authenticated){            
            history.push('/Home');     
        }
          
      }, [user]);

  const handleSubmit = (event) => {
    event.preventDefault();
    const data = new FormData(event.currentTarget);
    let body={
        userEmail: data.get("email"),
        password: data.get("password"),
    }
    
    dispatch(login({body:body, method: "POST" })).then(()=>{

        setShowWarning(true);
    });
    
  };

  return (
    <Container component="main" maxWidth="xs">
      <Box
        sx={{  
          marginTop: 8,
          display: "flex",
          flexDirection: "column",
          alignItems: "center",
        }}
      >
        <Typography component="h1" variant="h5">
          Sign in
        </Typography>
        <Box component="form" onSubmit={handleSubmit} noValidate sx={{ mt: 1 }}>
          <TextField
            margin="normal"
            required
            fullWidth
            id="email"
            label="Email Address"
            name="email"
            autoComplete="email"
            autoFocus
          />
          <TextField
            margin="normal"
            required
            fullWidth
            name="password"
            label="Password"
            type="password"
            id="password"
            autoComplete="current-password"
          />
          <FormControlLabel
            control={<Checkbox value="remember" color="primary" />}
            label="Remember me"
          />
          <Button
            type="submit"
            fullWidth
            variant="contained"
            sx={{ mt: 3, mb: 2 }}
          >
            Sign In
          </Button>   
         {showWarning && !authenticated && <Alert severity="warning">Invalid Credentials</Alert>}  
        </Box>
      </Box>
    </Container>
  );
}
