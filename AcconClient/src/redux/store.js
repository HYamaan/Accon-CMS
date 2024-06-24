import {configureStore} from "@reduxjs/toolkit";
import {AdminMenuSlice} from "@/redux/features/AdminMenuSlice";

export default configureStore({
    reducer: {
        adminMenu: AdminMenuSlice.reducer
    }
});
