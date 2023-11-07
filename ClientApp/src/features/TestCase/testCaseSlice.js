import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";

export const getTestCases = createAsyncThunk(
  "testCase/getTestCases",
  async (obj, { dispatch, getState }) => {
    let reqOptions = {};
    reqOptions.method = obj.method;
    return fetch("api/TestCases/GetTestCasesBySuitId/"+ obj.testSuitId, reqOptions).then((r) => {
      
        return r.json();
      

    });
  }
);

export const deleteTestCase = createAsyncThunk(
  "TestCase/deleteTestCase",
  async (obj, { dispatch, getState }) => {
    let reqOptions = {};
    reqOptions.method = obj.method;
    return fetch("api/TestCases/" + obj.id, reqOptions).then((r) => {
      
        return r.json();
      

    });
  }
);

export const addTestCase = createAsyncThunk(
  "TestCase/addTestCase",
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
    return fetch("api/TestCases", reqOptions).then((r) => {
      
        return r.json();
      

    });
  }
);

export const updateTestCase = createAsyncThunk(
  "TestCase/updateTestCase",
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
    return fetch("api/TestCases/"+ obj.id, reqOptions).then((r) => {
      
        return r.json();
      

    });
  }
);





const testCaseSlice = createSlice({
  name: "testCase",
  initialState: {
    testCases: [], 
    status: null,   
    loading: true,
  },
  reducers: {

    updateTestCases(state, { payload }){
      console.log(payload);
     state.testCases=payload;
    }
   
  },
  extraReducers: {
    [getTestCases.pending]: (state, action) => {
      state.status = "loading";
    },
    [getTestCases.fulfilled]: (state, { payload }) => {
      state.testCases = payload;
      state.status = "success";
    },
    [getTestCases.rejected]: (state, action) => {
      state.status = "failed";
      console.log("Error from getRoles", action.error.message);
    },

    [addTestCase.pending]: (state, action) => {
      state.status = "loading";
    },
    [addTestCase.fulfilled]: (state, { payload }) => {
     
      state.status = "success";
    },
    [addTestCase.rejected]: (state, action) => {
      state.status = "failed";
      console.log("Error from getRoles", action.error.message);
    },

    
    [deleteTestCase.pending]: (state, action) => {
      state.status = "loading";
    },
    [deleteTestCase.fulfilled]: (state, { payload }) => {
     
      state.status = "success";
    },
    [deleteTestCase.rejected]: (state, action) => {
      state.status = "failed";
      console.log("Error from getRoles", action.error.message);
    },

    [updateTestCase.pending]: (state, action) => {
      state.status = "loading";
    },
    [updateTestCase.fulfilled]: (state, { payload }) => {
     
      state.status = "success";
    },
    [updateTestCase.rejected]: (state, action) => {
      state.status = "failed";
      console.log("Error from getRoles", action.error.message);
    },
   
  },
});
export const { updateTestCases } = testCaseSlice.actions;
export default testCaseSlice.reducer;
