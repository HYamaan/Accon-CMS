import React from 'react';
import AdminNavBar from "@/Components/Admin/AdminNavBar";
import Language from "@/Components/Admin/Language";
import SocialMedia from "@/Components/Admin/SocialMedia";

const Index = () => {
    return <main className="d-flex">
        <AdminNavBar/>
        <div className="dashboard-content-body">
            {/*<Dashboard/>*/}
            {/*<Menu/>*/}
            {/*<Language/>*/}
            <SocialMedia/>
        </div>
    </main>
};

export default Index;
