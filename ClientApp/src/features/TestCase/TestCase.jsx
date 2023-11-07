import React, { useState, useEffect } from "react";
import { DataGrid } from "@mui/x-data-grid";
import Button from "@mui/material/Button";
import Stack from "@mui/material/Stack";
import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import DialogTitle from "@mui/material/DialogTitle";
import TextField from "@mui/material/TextField";
import { useForm } from "react-hook-form";
import MenuItem from "@mui/material/MenuItem";
import DeleteIcon from '@mui/icons-material/Delete';
import AddIcon from '@mui/icons-material/Add';
import "./TestCase.css";

import { useSelector, useDispatch } from "react-redux";
import {
  getTestCases,
  addTestCase,
  deleteTestCase,
  updateTestCases,
  updateTestCase,
} from "./testCaseSlice";
import { getTestSuits } from "../TestSuit/testSuitSlice";

export function TestCase() {
  const dispatch = useDispatch();
  const testSuitState = useSelector((state) => state.testSuit);
  const { testSuits } = testSuitState;
  const TestCaseState = useSelector((state) => state.testCase);
  const { testCases } = TestCaseState;

  const [addCase, setAddCase] = useState(false);
  const [editCase, setEditCase] = useState(false);
  const [runMode, setRunMode] = useState(true);
  const [selectedId, setSelectedId] = useState(0);
  const [selectedSuitId, setSelectedSuitId] = useState(0);
  const {
    register,
    handleSubmit,
    formState: { errors },
    reset,
  } = useForm();

  useEffect(() => {
    dispatch(getTestSuits({ method: "GET" }));
  }, []);

  useEffect(() => {
    if (testSuits && testSuits.length > 0) {
      setSelectedSuitId(testSuits[0]?.testSuitId);
      dispatch(
        getTestCases({ testSuitId: testSuits[0]?.testSuitId, method: "GET" })
      );
    } else {
      setSelectedSuitId(0);
      dispatch(updateTestCases([]));
    }
  }, [testSuits]);

  const onSubmit = (e) => {
    if (addCase) {
      let body = {
        testSuitId: selectedSuitId,
        testCaseId: 0,
        testCaseName: e.testCaseName,
        runMode: runMode,
      };
      dispatch(addTestCase({ body: body, method: "POST" })).then(() => {
        dispatch(
          getTestCases({ testSuitId: selectedSuitId, method: "GET" })
        );
      });
      setAddCase(false);
    } else {
      let body = {
        testSuitId: selectedSuitId,
        testCaseId: selectedId,
        testCaseName: e.testCaseName,
        runMode: runMode,
      };
      dispatch(
        updateTestCase({ id: selectedId, body: body, method: "PUT" })
      ).then(() => {
        dispatch(
          getTestCases({ testSuitId: selectedSuitId, method: "GET" })
        );
      });
      setEditCase(false);
    }
  };

  const selectRunmode = (e) => {
    setRunMode(e.target.value);
  };

  const handleSelectSuit = (e) => {
    setSelectedSuitId(e.target.value);
    dispatch(getTestCases({ testSuitId: e.target.value, method: "GET" }));
  };

  const addItem = () => {
    let body = {
      testSuitId: selectedSuitId,
      testCaseId: 0,
      testCaseName: "",
      runMode: true,
    };
    reset(body);
    setRunMode(true);
    setAddCase(true);
  };

  const removeItem = () => {
    dispatch(deleteTestCase({ id: selectedId, method: "DELETE" }));
    dispatch(
      updateTestCases(testCases.filter((x) => x.testCaseId != selectedId))
    );
  };
  const handleRowSelection = (e) => {
    setSelectedId(e.id);
  };

  const handleRowEdit = (e) => {
    setRunMode(e.row.runMode);
    reset(e.row);
    setEditCase(true);
  };

  const handleClose = () => {
    setAddCase(false);
    setEditCase(false);
  };

  return (
    <div >
      <Stack spacing={2} style={{float:"right", marginRight:"50px"}} direction="row">
        <TextField
          select
          label="Test Suit"
          className="form-sub-section"
          displayEmpty
          inputProps={{ "aria-label": "Without label" }}
          value={selectedSuitId}
          onChange={handleSelectSuit}
        >
          {testSuits ? (
            testSuits.map((testSuit) => (
              <MenuItem value={testSuit.testSuitId}>
                {testSuit.testSuitName}
              </MenuItem>
            ))
          ) : (
            <div></div>
          )}
        </TextField>
      </Stack>
      <div  style={{marginTop:"20px",marginLeft:"30px"}} >
        <Button onClick={addItem} endIcon={<AddIcon />}>Add New</Button>
        
      
      <div style={{ height: "30%", width: "35%" }}>
        <DataGrid
          editMode="none"
          onCellDoubleClick={handleRowEdit}
          onRowClick={handleRowSelection}
          getRowId={(row) => row.testCaseId}
          rows={testCases}
          columns={columns}
          initialState={{
            ...testSuits.initialState,
            pagination: { paginationModel: { pageSize: 5 } },
          }}
          pageSizeOptions={[5, 10, 25]}
        />
      </div>
      <Button onClick={removeItem} endIcon={<DeleteIcon />}>Remove Selected</Button>
      </div>
      <Dialog open={addCase || editCase}>
        <DialogTitle>Test Case</DialogTitle>
        <form onSubmit={handleSubmit(onSubmit)}>
          <DialogContent
            sx={{
              paddingTop: "5px !important",
              paddingBottom: "12px !important",
            }}
          >
            <div className="form-section">
              <TextField
                id="name"
                label="Test Case Name"
                fullWidth
                variant="outlined"
                className="form-section"
                name="testCaseName"
                {...register("testCaseName")}
              />
            </div>
            <div className="form-section-double">
              <div className="form-sub-section">
                <TextField
                  select
                  label="Run Mode"
                  className="form-sub-section"
                  displayEmpty
                  inputProps={{ "aria-label": "Without label" }}
                  value={runMode}
                  onChange={selectRunmode}
                >
                  <MenuItem value={true}>Yes</MenuItem>
                  <MenuItem value={false}>No</MenuItem>
                </TextField>
              </div>
            </div>
          </DialogContent>
          <DialogActions sx={{ padding: "12px 24px !important" }}>
            <Button onClick={handleClose}>Cancel</Button>
            <Button variant="contained" type="submit">
              Save
            </Button>
          </DialogActions>
        </form>
      </Dialog>
    </div>
  );
}

const columns = [
  { field: "testCaseName", headerName: "Name", width: 180, editable: true },
  {
    field: "runModeText",
    type: "singleSelect",
    valueOptions: ["true", "false"],
    headerName: "Run Mode",
    editable: true,
    align: "left",
    headerAlign: "left",
  },
];
