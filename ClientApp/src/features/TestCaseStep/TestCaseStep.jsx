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
import "./TestCaseStep.css";

import { useSelector, useDispatch } from "react-redux";
import {
  getTestCaseSteps,
  addTestCaseStep,
  deleteTestCaseStep,
  updateTestCaseSteps,
  updateTestCaseStep,
  GetActionKeys,
  GetLocatorTypes,
} from "./testCaseStepSlice";
import { getTestSuits } from "../TestSuit/testSuitSlice";
import { getTestCases, updateTestCases } from "../TestCase/testCaseSlice";

export function TestCaseStep() {
  const dispatch = useDispatch();
  const testSuitState = useSelector((state) => state.testSuit);
  const { testSuits } = testSuitState;
  const TestCaseState = useSelector((state) => state.testCase);
  const { testCases } = TestCaseState;
  const TestCaseStepState = useSelector((state) => state.testCaseStep);
  const { testCaseSteps, actionKeys, locatorTypes } = TestCaseStepState;

  const [addCaseStep, setAddCaseStep] = useState(false);
  const [editCaseStep, setEditCaseStep] = useState(false);
  const [runMode, setRunMode] = useState(true);
  const [screenshot, setScreenshot] = useState(true);
  const [actionKey, setActionKey] = useState(0);
  const [locatorType, setLocatorType] = useState(0);
  const [selectedId, setSelectedId] = useState(0);
  const [selectedSuitId, setSelectedSuitId] = useState(0);
  const [selectedCaseId, setSelectedCaseId] = useState(0);
  const {
    register,
    handleSubmit,
    formState: { errors },
    reset,
  } = useForm();

  useEffect(() => {
    dispatch(getTestSuits({ method: "GET" }));
    dispatch(GetActionKeys({ method: "GET" }));
    dispatch(GetLocatorTypes({ method: "GET" }));
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

  useEffect(() => {
    if (testCases && testCases.length > 0) {
      setSelectedCaseId(testCases[0]?.testCaseId);
      dispatch(
        getTestCaseSteps({
          testCaseId: testCases[0]?.testCaseId,
          method: "GET",
        })
      );
    } else {
      setSelectedCaseId(0);
      dispatch(updateTestCaseSteps([]));
    }
  }, [testCases]);

  const onSubmit = (e) => {
    if (addCaseStep) {
      let body = {
        testCaseId: selectedCaseId,
        testCaseStepId: 0,
        testCaseStepDesc: e.testCaseStepDesc,
        testCaseStepSequence: e.testCaseStepSequence,
        locator: e.locator,
        varible: e.varible,
        data: e.data,
        performanceTrack: e.performanceTrack,
        testCaseStepResult: e.testCaseStepResult,
        expMessage: e.expMessage,
        actionKeyId: actionKey,
        locatorTypeId: locatorType,
        runMode: runMode,
        screenShot: screenshot,
      };
      dispatch(addTestCaseStep({ body: body, method: "POST" })).then(() => {
        dispatch(
          getTestCaseSteps({ testCaseId: selectedCaseId, method: "GET" })
        );
      });
      setAddCaseStep(false);
    } else {
      let body = {
        testCaseId: selectedCaseId,
        testCaseStepId: selectedId,
        testCaseStepDesc: e.testCaseStepDesc,
        testCaseStepSequence: e.testCaseStepSequence,
        locator: e.locator,
        varible: e.varible,
        data: e.data,
        performanceTrack: e.performanceTrack,
        testCaseStepResult: e.testCaseStepResult,
        expMessage: e.expMessage,
        actionKeyId: actionKey,
        locatorTypeId: locatorType,
        runMode: runMode,
        screenShot: screenshot,
      };
      dispatch(
        updateTestCaseStep({ id: selectedId, body: body, method: "PUT" })
      ).then(() => {
        dispatch(
          getTestCaseSteps({ testCaseId: selectedCaseId, method: "GET" })
        );
      });
      setEditCaseStep(false);
    }
  };

  const selectRunMode = (e) => {
    console.log(e.target.value);
    setRunMode(e.target.value);
  };

  const selectScreenshot = (e) => {
    console.log(e.target.value);
    setScreenshot(e.target.value);
  };

  const selectActionKey = (e) => {
    console.log(e.target.value);
    setActionKey(e.target.value);
  };

  const selectLocatorType = (e) => {
    console.log(e.target.value);
    setLocatorType(e.target.value);
  };

  const handleSelectSuit = (e) => {
    setSelectedSuitId(e.target.value);
    dispatch(getTestCases({ testSuitId: e.target.value, method: "GET" }));
  };

  const handleSelectCase = (e) => {
    setSelectedCaseId(e.target.value);
    dispatch(getTestCaseSteps({ testCaseId: e.target.value, method: "GET" }));
  };

  const addItem = () => {
    setRunMode(true);
    setScreenshot(true);
    setActionKey(0);
    setLocatorType(0);
    let body = {
      testCaseId: selectedCaseId,
      testCaseStepId: 0,
      testCaseStepDesc: "",
      testCaseStepSequence: "",
      locator: "",
      varible: "",
      data: "",
      performanceTrack: "",
      testCaseStepResult: "",
      expMessage: "",
      actionKeyId: actionKey,
      locatorTypeId: locatorType,
      runMode: runMode,
      screenShot: screenshot,
    };
    reset(body);
    setAddCaseStep(true);
  };

  const removeItem = () => {
    dispatch(deleteTestCaseStep({ id: selectedId, method: "DELETE" }));

    dispatch(
      updateTestCaseSteps(
        testCaseSteps.filter((x) => x.testCaseStepId != selectedId)
      )
    );
  };
  const handleRowSelection = (e) => {
    setSelectedId(e.id);
  };

  const handleRowEdit = (e) => {
    // setSelectedTestCaseStep(e.row);
    setRunMode(e.row.runMode);
    setScreenshot(e.row.screenShot);
    setActionKey(e.row.actionKeyId);
    setLocatorType(e.row.locatorTypeId);
    reset(e.row);
    setEditCaseStep(true);
  };
  const handleClose = () => {
    setAddCaseStep(false);
    setEditCaseStep(false);
  };

  return (
    <div >
      <Stack spacing={2}  style={{marginTop:"20px",marginLeft:"750px", marginRight:"20px"}} direction="row" >
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
              <MenuItem key={testSuit.testSuitId} value={testSuit.testSuitId}>
                {testSuit.testSuitName}
              </MenuItem>
            ))
          ) : (
            <div></div>
          )}
        </TextField>

        <TextField
          select
          label="Test Case"
          className="form-sub-section"
          displayEmpty
          inputProps={{ "aria-label": "Without label" }}
          // defaultValue={selectedSuitId}
          value={selectedCaseId}
          onChange={handleSelectCase}
          // {...register("runMode")}
        >
          {testCases && testCases.length ? (
            testCases.map((testCase) => (
              <MenuItem key={testCase.testCaseId} value={testCase.testCaseId}>
                {testCase.testCaseName}
              </MenuItem>
            ))
          ) : (
            <div></div>
          )}
        </TextField>
      </Stack>
      <div  style={{marginTop:"0px",marginLeft:"20px", marginRight:"20px"}} >
        <Button onClick={addItem} endIcon={<AddIcon />}>Add New</Button>
      
    
      <div style={{ height: "50%", width: "100%" }}>
        <DataGrid
          editMode="none"
          onCellDoubleClick={handleRowEdit}
          onRowClick={handleRowSelection}
          getRowId={(row) => row.testCaseStepId}
          rows={testCaseSteps}
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
      <Dialog open={addCaseStep || editCaseStep} maxWidth="lg">
        <DialogTitle>Test Case Step</DialogTitle>
        <form onSubmit={handleSubmit(onSubmit)}>
          <DialogContent
            sx={{
              paddingTop: "5px !important",
              paddingBottom: "12px !important",
            }}
          >
            <div className="form-section-main">
              <div className="form-sub-section-two">
                <TextField
                  id="name"
                  label="Step Description"
                  fullWidth
                  variant="outlined"
                  className="form-sub-section-two"
                  {...register("testCaseStepDesc")}
                />
              </div>
              <div className="form-sub-section-four">
                <TextField
                  id="name"
                  label="Step Sequence"
                  type="number"
                  fullWidth
                  variant="outlined"
                  className="form-sub-section-four"
                  {...register("testCaseStepSequence")}
                />
              </div>
              <div className="form-sub-section-three">
                <TextField
                  select
                  label="Action Key"
                  className="form-sub-section-three"
                  displayEmpty
                  inputProps={{ "aria-label": "Without label" }}
                  value={actionKey}
                  onChange={selectActionKey}
                >
                  {actionKeys ? (
                    actionKeys.map((actionKey) => (
                      <MenuItem
                        key={actionKey.actionKeyId}
                        value={actionKey.actionKeyId}
                      >
                        {actionKey.actionKeyName}
                      </MenuItem>
                    ))
                  ) : (
                    <div></div>
                  )}
                </TextField>
              </div>
            </div>
            <div className="form-section-main">
     

              <div className="form-sub-section-three">
                <TextField
                  select
                  label="Locator Type"
                  className="form-sub-section-three"
                  displayEmpty
                  inputProps={{ "aria-label": "Without label" }}
                  value={locatorType}
                  onChange={selectLocatorType}
                >
                  {locatorTypes ? (
                    locatorTypes.map((locatorType) => (
                      <MenuItem
                        key={locatorType.locatorTypeId}
                        value={locatorType.locatorTypeId}
                      >
                        {locatorType.locatorTypeName}
                      </MenuItem>
                    ))
                  ) : (
                    <div></div>
                  )}
                </TextField>
              </div>
              <div className="form-sub-section-three">
                <TextField
                  select
                  label="Screenshot"
                  className="form-sub-section-three"
                  displayEmpty
                  inputProps={{ "aria-label": "Without label" }}
                  value={screenshot}
                  onChange={selectScreenshot}
                >
                  <MenuItem value={true}>Yes</MenuItem>
                  <MenuItem value={false}>No</MenuItem>
                </TextField>
              </div>
              <div className="form-sub-section-three">
                <TextField
                  select
                  label="Run Mode"
                  className="form-sub-section-three"
                  displayEmpty
                  inputProps={{ "aria-label": "Without label" }}
                  value={runMode}
                  onChange={selectRunMode}
                >
                  <MenuItem value={true}>Yes</MenuItem>
                  <MenuItem value={false}>No</MenuItem>
                </TextField>
              </div>
            </div>
            <div className="form-section-main">
            <div className="form-sub-section-two">
              <TextField
                id="name"
                label="Locator"
                fullWidth
                variant="outlined"
                className="form-sub-section-two"
                {...register("locator")}
              />
            </div>
            <div className="form-sub-section-two">
              <TextField
                id="name"
                label="Variable"
                fullWidth
                variant="outlined"
                className="form-sub-section-two"
                {...register("varible")}
              />
            </div>
            </div>
            <div className="form-section-main">
            <div className="form-sub-section-two">
              <TextField
                id="name"
                label="Data"
                fullWidth
                variant="outlined"
                className="form-sub-section-two"
                {...register("data")}
              />
            </div>
            <div className="form-sub-section-two">
              <TextField
                id="name"
                label="Performance Track"
                fullWidth
                variant="outlined"
                className="form-sub-section-two"
                {...register("performanceTrack")}
              />
            </div>
            </div>
            <div className="form-section-main">
            <div className="form-sub-section-two">
              <TextField
                id="name"
                label="Result"
                fullWidth
                variant="outlined"
                className="form-sub-section-two"
                {...register("testCaseStepResult")}
              />
            </div>
            <div className="form-sub-section-two">
              <TextField
                id="name"
                label="Expected Message"
                fullWidth
                variant="outlined"
                className="form-sub-section-two"
                {...register("expMessage")}
              />
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
  {
    field: "testCaseStepDesc",
    headerName: "Description",
    width: 180,
    editable: true,
  },
  {
    field: "testCaseStepSequence",
    headerName: "Sequence",
    width: 180,
    editable: true,
  },
  {
    field: "actionKey",
    type: "singleSelect",
    valueOptions: ["true", "false"],
    headerName: "Action Key",
    editable: true,
    align: "left",
    headerAlign: "left",
  },
  {
    field: "locatorType",
    type: "singleSelect",
    valueOptions: ["true", "false"],
    headerName: "Locator Type",
    editable: true,
    align: "left",
    headerAlign: "left",
  },
  { field: "locator", headerName: "Locator", width: 180, editable: true },
  { field: "varible", headerName: "Variable", width: 180, editable: true },
  { field: "data", headerName: "Data", width: 180, editable: true },
  {
    field: "performanceTrack",
    headerName: "Performance Track",
    width: 180,
    editable: true,
  },
  {
    field: "testCaseStepResult",
    headerName: "Result",
    width: 180,
    editable: true,
  },
  {
    field: "expMessage",
    headerName: "Expected Message",
    width: 180,
    editable: true,
  },
  {
    field: "screenShotText",
    type: "singleSelect",
    valueOptions: ["true", "false"],
    headerName: "Screenshot",
    editable: true,
    align: "left",
    headerAlign: "left",
  },
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
