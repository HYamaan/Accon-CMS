import React from 'react';
import AdminNavBar from "@/Components/Admin/AdminNavBar";
import Language from "@/Components/Admin/Language";
import SocialMedia from "@/Components/Admin/SocialMedia";
import OneFileUpload from "@/Components/Ui/OneFileUpload";
import Settings from "@/Components/Admin/Settings/Settings";
import dynamic from "next/dynamic";
import Dashboard from "@/Components/Admin/Dashboard";
import Menu from "@/Components/Admin/Menu";

const ViewSlider = dynamic(() => import('@/Components/Admin/Slider/ViewSlider'), {
    ssr: false
});
const ViewService = dynamic(() => import('@/Components/Admin/Service/ViewService'), {
    ssr: false
});

const ViewPhotoGallery = dynamic(() => import('@/Components/Admin/PhotoGallery/ViewPhotoGallery'), {
    ssr: false
});

const ViewPortfolio = dynamic(() => import('@/Components/Admin/Portfolio/ViewPortfolio'), {
    ssr: false
});

const ViewTeamMember = dynamic(() => import('@/Components/Admin/TeamMember/ViewTeamMember'), {
    ssr: false
});
const ViewTestimonial = dynamic(() => import('@/Components/Admin/Testimonial/ViewTestimonial'), {
    ssr: false
});

const ViewPartner = dynamic(() => import('@/Components/Admin/Partner/ViewPartner'), {
    ssr: false
});
const ViewWhyChoouseUs = dynamic(() => import('@/Components/Admin/WhyChooseUs/ViewWhyChooseUs'), {
    ssr: true
});


const Index = ({slug}) => {
    return (
        <main className="d-flex">
            <AdminNavBar/>
            <div className="dashboard-content-body">
                {slug === null && <Dashboard/>}
                {slug === "menu" && <Menu/>}
                {slug === "social-media" && <SocialMedia/>}
                {slug === "language" && <Language/>}
                {slug === "settings" && <Settings/>}
                {slug === "slider" && <ViewSlider/>}
                {slug === "service" && <ViewService/>}
                {slug === "photo-gallery" && <ViewPhotoGallery/>}
                {slug === "portfolio" && <ViewPortfolio/>}
                {slug === "team-member" && <ViewTeamMember/>}
                {slug === "testimonial" && <ViewTestimonial/>}
                {slug === "partner" && <ViewPartner/>}
                {slug === "why-choose-us" && <ViewWhyChoouseUs/>}
            </div>
        </main>
    );
};

export default Index;

export const getServerSideProps = async (context) => {
    const {params} = context;
    const {slug} = params;
    return {
        props: {
            slug: slug || null
        }
    }
}
