import { useRouter } from 'next/router';
import React from 'react';
import { LazyLoadImage } from 'react-lazy-load-image-component';

const AdminHeader = () => {

    const router = useRouter();



    const getMainPage = async ()=>{
    await router.push("/");
    }
    return <header className='main-header'>
    <LazyLoadImage 
    src={"/logo.png"}
    alt="deneme"
    className='main-header_logo'
    />
    <div>
    <div>
    <IoMenu />
    <div>Admin Panel</div>
    </div>
    <div>
        <div>
            Visit Website
        </div>
        <div>
            <LazyLoadImage
            src={"team-member-1.jpg"}
            alt={"team-member-1.jpg"}/>
            <span>John Doe</span>
        </div>
    </div>
    </div>
    </header>
};

export default AdminHeader;
