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
import AddSlider from "@/Components/Admin/Slider/AddSlider";
import AddFaq from "@/Components/Admin/Faq/AddFaq";
import AddPhotoGallery from "@/Components/Admin/PhotoGallery/AddPhotoGallery";
import AddPortfolioCategory from "@/Components/Admin/Portfolio/AddPortfolioCategory";
import AddDesignation from "@/Components/Admin/TeamMember/AddDesignation";
import AddTeamMember from "@/Components/Admin/TeamMember/AddTeamMember";
import AddTestimonial from "@/Components/Admin/Testimonial/AddTestimonial";
import AddPartner from "@/Components/Admin/Partner/AddPartner";
import AddWhyChooseUs from "@/Components/Admin/WhyChooseUs/AddWhyChooseUs";
import AddPortfolio from "@/Components/Admin/Portfolio/AddPortfolio";
import AddService from "@/Components/Admin/Service/AddService";
import AddNewsCategory from "@/Components/Admin/News/Category/AddNewsCategory";
import AddViewNews from "@/Components/Admin/News/News/AddViewNews";

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
                {(combinedSlug === "slider/add" || combinedSlug === "slider/edit/add") && <AddSlider/>}
                {combinedSlug === "service" && <ViewService/>}
                {(combinedSlug === "service/add" || combinedSlug === "service/edit/add") && <AddService/>}
                {combinedSlug === "faq" && <ViewFaq/>}
                {(combinedSlug === "faq/add" || combinedSlug === "faq/edit/add") && <AddFaq/>}
                {combinedSlug === "faq/main-photo" && <MainPhoto/>}
                {combinedSlug === "photo-gallery" && <ViewPhotoGallery/>}
                {(combinedSlug === "photo-gallery/add" || combinedSlug === "photo-gallery/edit/add") && <AddPhotoGallery/>}
                {combinedSlug === "portfolio" && <ViewPortfolio/>}
                {(combinedSlug === "portfolio/add" || combinedSlug === "portfolio/edit/add") && <AddPortfolio/>}
                {combinedSlug === "portfolio-category" && <PortfolioCategory/>}
                {(combinedSlug === "portfolio-category/add" || combinedSlug === "portfolio-category/edit/add")  && <AddPortfolioCategory/>}
                {combinedSlug === "team-member" && <ViewTeamMember/>}
                {(combinedSlug === "team-member/add" || combinedSlug === "team-member/edit/add") && <AddTeamMember/>}
                {combinedSlug === "team-member/designation" && <Designation/>}
                {(combinedSlug === "team-member/designation/add" || combinedSlug === "team-member/designation/edit/add") && <AddDesignation/>}
                {combinedSlug === "testimonial" && <ViewTestimonial/>}
                {(combinedSlug === "testimonial/add" || combinedSlug === "testimonial/edit/add") && <AddTestimonial/>}
                {combinedSlug === "testimonial/main-photo" && <TestimonialMainPhoto/>}
                {combinedSlug === "partners" && <ViewPartner/>}
                {(combinedSlug === "partners/add" || combinedSlug === "partners/edit/add") && <AddPartner/>}
                {combinedSlug === "why-choose-us" && <ViewWhyChoouseUs/>}
                {(combinedSlug === "why-choose-us/add" || combinedSlug === "why-choose-us/edit/add") && <AddWhyChooseUs/>}
                {combinedSlug === "why-choose-us/main-photo" && <WhyChooseUsMainPhoto/>}
                {combinedSlug === "why-choose-us/background-item" && <WhyChooseUsBackgroundPhoto/>}
                {(combinedSlug === "page" || (slug && slug[0]==="page")) && <Page combinedSlug={combinedSlug} slug={slug}/>}
                {combinedSlug === "news" && <ViewNews/>}
                {(combinedSlug === "news/add" || combinedSlug === "news/edit/add") && <AddViewNews/>}
                {combinedSlug === "news-category" && <ViewNewsCategory/>}
                {(combinedSlug=== "news-category/add" || combinedSlug === "news-category/edit/add") && <AddNewsCategory/>}
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
