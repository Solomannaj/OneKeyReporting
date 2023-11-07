import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";

export const login = createAsyncThunk(
  "login/login",
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
    return fetch("api/Login", reqOptions).then((r) => {
      
        return r.json();
      

    });
  }
);

const loginSlice = createSlice({
  name: "login",
  initialState: {
    user: {}, 
    authenticated:false,
    status: null,   
    loading: true,
  },
  reducers: {
   updateUser(state, { payload }){
     console.log(payload);
    state.user=payload;
   }
  },
  extraReducers: {
  

    [login.pending]: (state, action) => {
      state.status = "loading";
    },
    [login.fulfilled]: (state, { payload }) => {
     
      state.status = "success";
      
      if(payload){
        state.authenticated=true;
        state.user=payload;
      }      
      else
      {
        state.authenticated=false;
        state.user={};
      }
      
    },
    [login.rejected]: (state, action) => {
      state.status = "failed";
      state.authenticated=false;
        state.user={};
      console.log("Error from getRoles", action.error.message);
    },
  },
});
export const { updateUser } = loginSlice.actions;
export default loginSlice.reducer;
