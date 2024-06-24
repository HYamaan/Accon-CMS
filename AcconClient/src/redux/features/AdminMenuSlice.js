import {createSlice} from "@reduxjs/toolkit";


const initialState = {
    adminLogoClicked: false,
    menuClicked: false,
}

export const AdminMenuSlice = createSlice({
    name: 'adminMenu',
    initialState,
    reducers: {
        setAdminMenuLogoClicked: (state, action) => {
            state.adminLogoClicked = action.payload
        },
        setMenuLogoClicked : (state, action) => {
            state.menuClicked = action.payload
        }
    }
});
export const {setAdminMenuLogoClicked,setMenuLogoClicked} = AdminMenuSlice.actions;
