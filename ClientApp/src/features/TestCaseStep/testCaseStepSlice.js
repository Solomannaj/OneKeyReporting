import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";

export const getTestCaseSteps = createAsyncThunk(
  "TestCaseStep/getTestCaseSteps",
  async (obj, { dispatch, getState }) => {
    let reqOptions = {};
    reqOptions.method = obj.method;
    return fetch("api/TestCaseSteps/GetTestCaseStepsByCaseId/"+ obj.testCaseId, reqOptions).then((r) => {
      
        return r.json();
      

    });
  }
);

export const GetActionKeys = createAsyncThunk(
  "TestCaseStep/GetActionKeys",
  async (obj, { dispatch, getState }) => {
    let reqOptions = {};
    reqOptions.method = obj.method;
    return fetch("api/TestCaseSteps/GetActionKeys", reqOptions).then((r) => {
      
        return r.json();
      

    });
  }
);

export const GetLocatorTypes = createAsyncThunk(
  "TestCaseStep/GetLocatorTypes",
  async (obj, { dispatch, getState }) => {
    let reqOptions = {};
    reqOptions.method = obj.method;
    return fetch("api/TestCaseSteps/GetLocatorTypes", reqOptions).then((r) => {
      
        return r.json();
      

    });
  }
);

export const deleteTestCaseStep = createAsyncThunk(
  "TestCaseStep/deleteTestCaseStep",
  async (obj, { dispatch, getState }) => {
    let reqOptions = {};
    reqOptions.method = obj.method;
    return fetch("api/TestCaseSteps/" + obj.id, reqOptions).then((r) => {
      
        return r.json();
      

    });
  }
);

export const addTestCaseStep = createAsyncThunk(
  "TestCaseStep/addTestCaseStep",
  async (obj, { dispatch, getState }) => {
    let reqOptions = {};
    let headers = new Headers({
      "Cache-Control": "no-cache",
      Pragma: "no-cache",
      Expires: 0,
    });
    headers.set("Access-Control-Allow-Origin", "*");
    headers.append("Content-Type", "application/json");
    headers.append("Accept", "application/json");
    reqOptions.method = obj.method;
    reqOptions.body = JSON.stringify(obj.body);
    reqOptions.headers=headers;
    return fetch("api/TestCaseSteps", reqOptions).then((r) => {
      
        return r.json();
      

    });
  }
);

export const updateTestCaseStep = createAsyncThunk(
  "TestCaseStep/updateTestCaseStep",
  async (obj, { dispatch, getState }) => {
    let reqOptions = {};
    let headers = new Headers({
      "Cache-Control": "no-cache",
      Pragma: "no-cache",
      Expires: 0,
    });
    headers.set("Access-Control-Allow-Origin", "*");
    headers.append("Content-Type", "application/json");
    headers.append("Accept", "application/json");
    reqOptions.method = obj.method;
    reqOptions.body = JSON.stringify(obj.body);
    reqOptions.headers=headers;
    return fetch("api/TestCaseSteps/"+ obj.id, reqOptions).then((r) => {
      
        return r.json();
      

    });
  }
);





const testCaseStepSlice = createSlice({
  name: "testCaseStep",
  initialState: {
    testCaseSteps: [], 
    actionKeys: [], 
    locatorTypes: [], 
    status: null,   
    loading: true,
  },
  reducers: {

    updateTestCaseSteps(state, { payload }){
      console.log(payload);
     state.testCaseSteps=payload;
    }
   
  },
  extraReducers: {
    [getTestCaseSteps.pending]: (state, action) => {
      state.status = "loading";
    },
    [getTestCaseSteps.fulfilled]: (state, { payload }) => {
      let testCaseSteps=payload;
      if(testCaseSteps && testCaseSteps.length > 0){
        testCaseSteps.forEach(element => {
          element.actionKey=state.actionKeys.find(x=>x.actionKeyId==element.actionKeyId)?.actionKeyName;
          element.locatorType=state.locatorTypes.find(x=>x.locatorTypeId==element.locatorTypeId)?.locatorTypeName;
        });
      }
      state.testCaseSteps = testCaseSteps;


      state.status = "success";
    },
    [getTestCaseSteps.rejected]: (state, action) => {
      state.status = "failed";
      console.log("Error from getRoles", action.error.message);
    },

    [GetActionKeys.pending]: (state, action) => {
      state.status = "loading";
    },
    [GetActionKeys.fulfilled]: (state, { payload }) => {
      state.actionKeys = payload;
      state.status = "success";
    },
    [GetActionKeys.rejected]: (state, action) => {
      state.status = "failed";
      console.log("Error from getRoles", action.error.message);
    },

    [GetLocatorTypes.pending]: (state, action) => {
      state.status = "loading";
    },
    [GetLocatorTypes.fulfilled]: (state, { payload }) => {
      state.locatorTypes = payload;
      state.status = "success";
    },
    [GetLocatorTypes.rejected]: (state, action) => {
      state.status = "failed";
      console.log("Error from getRoles", action.error.message);
    },

    [addTestCaseStep.pending]: (state, action) => {
      state.status = "loading";
    },
    [addTestCaseStep.fulfilled]: (state, { payload }) => {
     
      state.status = "success";
    },
    [addTestCaseStep.rejected]: (state, action) => {
      state.status = "failed";
      console.log("Error from getRoles", action.error.message);
    },

    
    [deleteTestCaseStep.pending]: (state, action) => {
      state.status = "loading";
    },
    [deleteTestCaseStep.fulfilled]: (state, { payload }) => {
     
      state.status = "success";
    },
    [deleteTestCaseStep.rejected]: (state, action) => {
      state.status = "failed";
      console.log("Error from getRoles", action.error.message);
    },

    [updateTestCaseStep.pending]: (state, action) => {
      state.status = "loading";
    },
    [updateTestCaseStep.fulfilled]: (state, { payload }) => {
     
      state.status = "success";
    },
    [updateTestCaseStep.rejected]: (state, action) => {
      state.status = "failed";
      console.log("Error from getRoles", action.error.message);
    },
   
  },
});
export const { updateTestCaseSteps } = testCaseStepSlice.actions;
export default testCaseStepSlice.reducer;
