import * as React from 'react';
import { Route } from 'react-router';
import  Home  from './features/Home/Home';
import {Layout} from './features/Home/Layout'
import Login from './features/Login/Login';

import './custom.css'

export default () => (
        <div>
             <Layout></Layout>
          
  
  <Route exact path='/' component={Login} />
  <Route exact path='/Home' component={Home} /> 
                </div>

        
      
    
);
