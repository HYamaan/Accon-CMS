import {createSlice} from "@reduxjs/toolkit";


const initialState = {
    adminMenuClicked: false
}

export const AdminMenuSlice = createSlice({
    name: 'adminMenu',
    initialState,
    reducers: {
        setAdminMenuClicked: (state, action) => {
            state.adminMenuClicked = action.payload
        }
    }
});
export const {setAdminMenuClicked} = AdminMenuSlice.actions;
