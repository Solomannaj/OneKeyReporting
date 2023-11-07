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
import "./TestSuit.css";

import { useSelector, useDispatch } from "react-redux";
import {
  getTestSuits,
  addTestSuit,
  deleteTestSuit,
  updateTestSuits,
  updateTestSuit,
} from "./testSuitSlice";

export function TestSuit() {
  const dispatch = useDispatch();
  const testSuitState = useSelector((state) => state.testSuit);
  const { testSuits } = testSuitState;

  const [addSuit, setAddSuit] = useState(false);
  const [editSuit, setEditSuit] = useState(false);
  const [runMode, setRunMode] = useState(true);
  const [selectedId, setSelectedId] = useState(0); 
  const {
    register,
    handleSubmit,
    formState: { errors },
    reset,
  } = useForm();

  useEffect(() => {
    dispatch(getTestSuits({ method: "GET" }));
  }, []);

  const onSubmit = (e) => {
    if (addSuit) {
      let body = {
        testSuitId: 0,
        testSuitName: e.testSuitName,
        runMode: runMode,
      };
      dispatch(addTestSuit({ body: body, method: "POST" })).then(() => {
        dispatch(getTestSuits({ method: "GET" }));
      });
      setAddSuit(false);
    } else {
      let body = {
        testSuitId: selectedId,
        testSuitName: e.testSuitName,
        runMode: runMode,
      };
      dispatch(
        updateTestSuit({ id: selectedId, body: body, method: "PUT" })
      ).then(() => {
        dispatch(getTestSuits({ method: "GET" }));
      });
      setEditSuit(false);
    }
  };

  const selectRunmode = (e) => {
    setRunMode(e.target.value);
  };

  const addItem = () => {
    let body = { testSuitId: 0, testSuitName: "", runMode: true };
    reset(body);
    setRunMode(true);
    setAddSuit(true);
  };

  const removeItem = () => {
    dispatch(deleteTestSuit({ id: selectedId, method: "DELETE" }));
    dispatch(
      updateTestSuits(testSuits.filter((x) => x.testSuitId != selectedId))
    );
  };
  const handleRowSelection = (e) => {
    setSelectedId(e.id);
  };

  const handleRowEdit = (e) => {
    reset(e.row);
    setRunMode(e.row.runMode);
    setEditSuit(true);
  };
  const handleClose = () => {
    setAddSuit(false);
    setEditSuit(false);
  };

  return (
    <div style={{ PaddingTop: 0 }}>
      <div  style={{marginTop:"20px",marginLeft:"30px"}} >

      <Button onClick={addItem} endIcon={<AddIcon />}>Add New</Button>
      <div style={{ height: "100%", width: "35%" }}>
        <DataGrid
       
          editMode="none"
          onCellDoubleClick={handleRowEdit}
          onRowClick={handleRowSelection}
          getRowId={(row) => row.testSuitId}
          rows={testSuits}
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
      <Dialog open={addSuit || editSuit}>
        <DialogTitle>Test Suit</DialogTitle>
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
                label="Test Suit Name"
                fullWidth
                variant="outlined"
                className="form-section"
                {...register("testSuitName")}
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
  { field: "testSuitName", headerName: "Name", width: 180, editable: true },
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
