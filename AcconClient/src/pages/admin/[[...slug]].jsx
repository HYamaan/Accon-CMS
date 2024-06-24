import React from 'react';

const Index = ({slug}) => {
    console.log("slug", slug);
    if(slug == undefined){
        return (
            <div>
                <h1>Admin</h1>
            </div>
        );
    }
    return (
        <div>

        </div>
    );
};

export default Index;

export const getServersideProps = async (context) => {
    return {
        props: {
            slug: context.params.slug
        }
    }
}
