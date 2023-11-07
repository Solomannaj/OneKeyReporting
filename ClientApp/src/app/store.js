import { configureStore } from "@reduxjs/toolkit";
import testSuitReducer from "../features/TestSuit/testSuitSlice";
import testCaseReducer from "../features/TestCase/testCaseSlice";
import testCaseStepReducer from "../features/TestCaseStep/testCaseStepSlice";
import loginReducer from "../features/Login/loginSlice";

export const store = configureStore({
  reducer: {
    testSuit: testSuitReducer,
    testCase: testCaseReducer,
    testCaseStep: testCaseStepReducer,
    login:loginReducer
  },
});
