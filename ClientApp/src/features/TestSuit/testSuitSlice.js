import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";

export const getTestSuits = createAsyncThunk(
  "testSuit/getTestSuits",
  async (obj, { dispatch, getState }) => {
    let reqOptions = {};
    reqOptions.method = obj.method;
    return fetch("api/TestSuits", reqOptions).then((r) => {
      
        return r.json();
      

    });
  }
);

export const deleteTestSuit = createAsyncThunk(
  "testSuit/deleteTestSuit",
  async (obj, { dispatch, getState }) => {
    let reqOptions = {};
    reqOptions.method = obj.method;
    return fetch("api/TestSuits/" + obj.id, reqOptions).then((r) => {
      
        return r.json();
      

    });
  }
);

export const addTestSuit = createAsyncThunk(
  "testSuit/addTestSuit",
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
    return fetch("api/TestSuits", reqOptions).then((r) => {
      
        return r.json();
      

    });
  }
);

export const updateTestSuit = createAsyncThunk(
  "testSuit/updateTestSuit",
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
    return fetch("api/TestSuits/"+ obj.id, reqOptions).then((r) => {
      
        return r.json();
      

    });
  }
);



const testSuitSlice = createSlice({
  name: "testSuit",
  initialState: {
    testSuits: [], 
    status: null,   
    loading: true,
  },
  reducers: {
   updateTestSuits(state, { payload }){
     console.log(payload);
    state.testSuits=payload;
   }
  },
  extraReducers: {
    [getTestSuits.pending]: (state, action) => {
      state.status = "loading";
    },
    [getTestSuits.fulfilled]: (state, { payload }) => {
      state.testSuits = payload;
      state.status = "success";
    },
    [getTestSuits.rejected]: (state, action) => {
      state.status = "failed";
      console.log("Error from getRoles", action.error.message);
    },

    [addTestSuit.pending]: (state, action) => {
      state.status = "loading";
    },
    [addTestSuit.fulfilled]: (state, { payload }) => {
     
      state.status = "success";
    },
    [addTestSuit.rejected]: (state, action) => {
      state.status = "failed";
      console.log("Error from getRoles", action.error.message);
    },

    
    [deleteTestSuit.pending]: (state, action) => {
      state.status = "loading";
    },
    [deleteTestSuit.fulfilled]: (state, { payload }) => {
     
      state.status = "success";
    },
    [deleteTestSuit.rejected]: (state, action) => {
      state.status = "failed";
      console.log("Error from getRoles", action.error.message);
    },

    [updateTestSuit.pending]: (state, action) => {
      state.status = "loading";
    },
    [updateTestSuit.fulfilled]: (state, { payload }) => {
     
      state.status = "success";
    },
    [updateTestSuit.rejected]: (state, action) => {
      state.status = "failed";
      console.log("Error from getRoles", action.error.message);
    },
   
  },
});
export const { updateTestSuits } = testSuitSlice.actions;
export default testSuitSlice.reducer;
