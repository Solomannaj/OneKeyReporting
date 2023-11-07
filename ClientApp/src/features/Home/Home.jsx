import React, { useState, useEffect } from "react";
import Box from "@mui/material/Box";
import Tabs from "@mui/material/Tabs";
import Tab from "@mui/material/Tab";
import { TestSuit } from "../TestSuit/TestSuit";
import { TestCase } from "../TestCase/TestCase";
import { TestCaseStep } from "../TestCaseStep/TestCaseStep";
import "./Home.css";
import { useSelector } from "react-redux";
import { useHistory } from "react-router-dom";

export default function NavBar() {
  const history = useHistory();
  const [value, setValue] = React.useState(1);
  const loginState = useSelector((state) => state.login);
  const { user,authenticated } = loginState;

  const handleTabChange = (event, newValue) => {
    setValue(newValue);
  };

  useEffect(() => {
    if(!authenticated){
      history.push('/');   
    }
  }, []);

  return (
    <div>
      <Box className="tafwa-container">
        <Box className="tabs-container">
          <Tabs
            value={value}
            onChange={handleTabChange}
            aria-label="content tabs"
            TabIndicatorProps={{
              style: {
                top: 0,
              },
            }}
          >
            <Tab
              className="tafwa-tabs"
              classes={{
                selected: "tab-selected",
              }}
              value="1"
              label="Test Suits"
            />
            <Tab
              className="tafwa-tabs"
              classes={{
                selected: "tab-selected",
              }}
              value="2"
              label="Test Cases"
            />
            <Tab
              className="tafwa-tabs"
              classes={{
                selected: "tab-selected",
              }}
              value="3"
              label="Test Case Steps"
            />
          </Tabs>
        </Box>

        {value == 1 && <TestSuit />}
        {value == 2 && <TestCase />}
        {value == 3 && <TestCaseStep />}
      </Box>
    </div>
  );
}
