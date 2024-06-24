import React from 'react';
import AdminNavBar from "@/Components/Admin/AdminNavBar";

const Index = ({slug}) => {
    console.log("slug", slug);
    return <>
        <AdminNavBar/>
    </>
};

export default Index;

export const getServersideProps = async (context) => {
    return {
        props: {
            slug: context.params.slug
        }
    }
}
