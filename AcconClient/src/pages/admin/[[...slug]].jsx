import React from 'react';
import AdminNavBar from "@/Components/Admin/AdminNavBar";
import Language from "@/Components/Admin/Language";
import SocialMedia from "@/Components/Admin/SocialMedia";
import Settings from "@/Components/Admin/Settings/Settings";
import dynamic from "next/dynamic";
import Dashboard from "@/Components/Admin/Dashboard";
import Menu from "@/Components/Admin/Menu";
import MainPhoto from "@/Components/Admin/Faq/MainPhoto";
import TestimonialMainPhoto from "@/Components/Admin/Testimonial/TestimonialMainPhoto";
import WhyChooseUsMainPhoto from "@/Components/Admin/WhyChooseUs/WhyChooseUsMainPhoto";
import WhyChooseUsBackgroundPhoto from "@/Components/Admin/WhyChooseUs/WhyChooseUsBackgroundPhoto";
import Page from "@/Components/Admin/Pages/Page";

const ViewSlider = dynamic(() =>
    import('@/Components/Admin/Slider/ViewSlider'), {
    ssr: false
});
const ViewService = dynamic(() =>
    import('@/Components/Admin/Service/ViewService'), {
    ssr: false
});

const ViewPhotoGallery = dynamic(() =>
    import('@/Components/Admin/PhotoGallery/ViewPhotoGallery'), {
    ssr: false
});

const ViewPortfolio = dynamic(() =>
    import('@/Components/Admin/Portfolio/ViewPortfolio'), {
    ssr: false
});

const ViewTeamMember = dynamic(() =>
    import('@/Components/Admin/TeamMember/ViewTeamMember'), {
    ssr: false
});
const ViewTestimonial = dynamic(() =>
    import('@/Components/Admin/Testimonial/ViewTestimonial'), {
    ssr: false
});

const ViewPartner = dynamic(() =>
    import('@/Components/Admin/Partner/ViewPartner'), {
    ssr: false
});
const ViewWhyChoouseUs = dynamic(() =>
    import('@/Components/Admin/WhyChooseUs/ViewWhyChooseUs'), {
    ssr: true
});

const ViewFaq = dynamic(() =>
        import('@/Components/Admin/Faq/ViewFaq'),
    {ssr: false}
);
const PortfolioCategory= dynamic(() =>
    import('@/Components/Admin/Portfolio/PortfolioCategory'), {ssr: false});

const Designation = dynamic(() =>
    import('@/Components/Admin/TeamMember/Designation'), {ssr: false});
const ViewNewsCategory = dynamic(() =>
    import('@/Components/Admin/News/Category/ViewNewsCategory'), {ssr: false});
const ViewNews = dynamic(() =>
    import('@/Components/Admin/News/News/ViewNews'), {ssr: false});

const Index = ({combinedSlug,slug}) => {
    return (
        <main className="d-flex">
            <AdminNavBar/>
            <div className="dashboard-content-body">
                {combinedSlug === null && <Dashboard/>}
                {(combinedSlug === "settings" ||(slug &&  slug[0] === "settings") )&& <Settings combinedSlug={combinedSlug} slug={slug}/>}
                {combinedSlug === "menu" && <Menu/>}
                {combinedSlug === "slider" && <ViewSlider/>}
                {combinedSlug === "service" && <ViewService/>}
                {combinedSlug === "faq" && <ViewFaq/>}
                {combinedSlug === "faq/main-photo" && <MainPhoto/>}
                {combinedSlug === "photo-gallery" && <ViewPhotoGallery/>}
                {combinedSlug === "portfolio" && <ViewPortfolio/>}
                {combinedSlug === "portfolio-category" && <PortfolioCategory/>}
                {combinedSlug === "team-member" && <ViewTeamMember/>}
                {combinedSlug === "team-member/designation" && <Designation/>}
                {combinedSlug === "testimonial" && <ViewTestimonial/>}
                {combinedSlug === "testimonial/main-photo" && <TestimonialMainPhoto/>}
                {combinedSlug === "partners" && <ViewPartner/>}
                {combinedSlug === "why-choose-us" && <ViewWhyChoouseUs/>}
                {combinedSlug === "why-choose-us/main-photo" && <WhyChooseUsMainPhoto/>}
                {combinedSlug === "why-choose-us/background-item" && <WhyChooseUsBackgroundPhoto/>}
                {(combinedSlug === "page" || (slug && slug[0]==="page")) && <Page combinedSlug={combinedSlug} slug={slug}/>}
                {combinedSlug === "news" && <ViewNews/>}
                {combinedSlug === "news-category" && <ViewNewsCategory/>}
                {combinedSlug === "language" && <Language/>}
                {combinedSlug === "social-media" && <SocialMedia/>}
            </div>
        </main>
    );
};

export default Index;

export const getServerSideProps = async (context) => {
    const {params} = context;
    const {slug} = params;

    const combinedSlug = Array.isArray(slug) ? slug.join('/') : slug;
    return {
        props: {
            combinedSlug: combinedSlug || null,
            slug: slug || null
        }
    }
}
