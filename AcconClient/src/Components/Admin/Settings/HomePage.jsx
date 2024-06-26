import React, {useState} from 'react';
import HomePageTabContent from "@/Components/Ui/HomePageComponent/HomePageTabContent";
import UploadLogoComponent from "@/Components/Ui/UploadLogoComponent";
import HomePageTabContentOneInput from "@/Components/Ui/HomePageComponent/HomePageTabContentOneInput";
import CounterSettingsContent from "@/Components/Ui/HomePageComponent/CounterSettingsContent";

const HomePage = () => {
    const [whyChooseUs, setWhyChooseUs] = useState({
        title: "WHY CHOOSE US",
        subtitle: "Lorem ipsum dolor sit amet, consectetur adipisicing elit Deserunt libero voluptate",
        status: true
    });
    const [services, setServices] = useState({
        title: "SERVICES",
        subtitle: "Lorem ipsum dolor sit amet, consectetur adipisicing elit Deserunt libero voluptate",
        status: true
    });
    const [portfolio, setPortfolio] = useState({
        title: "Portfolio",
        subtitle: "Lorem ipsum dolor sit amet, consectetur adipisicing elit Deserunt libero voluptate",
        status: true
    });
    const [team, setTeam] = useState({
        title: "EXPERIENCED TEAM",
        subtitle: "Lorem ipsum dolor sit amet, consectetur adipisicing elit Deserunt libero voluptate",
        status: true
    });
    const [testimonial, setTestimonial] = useState({
        title: "WHAT OUR CLIENTS SAY",
        subtitle: "Lorem ipsum dolor sit amet, consectetur adipisicing elit Deserunt libero voluptate",
        status: true
    });
    const [faq, setFaq] = useState({
        title: "Have Some Questions?",
        subtitle: "Lorem ipsum dolor sit amet, consectetur adipisicing elit Deserunt libero voluptate",
        status: true
    });
    const [gallery, setGallery] = useState({
        title: "PHOTO GALLERY",
        subtitle: "Lorem ipsum dolor sit amet, consectetur adipisicing elit Deserunt libero voluptate",
        status: true
    });
    const [recentPost, setRecentPost] = useState({
        title: "RECENT POSTS",
        subtitle: "Lorem ipsum dolor sit amet, consectetur adipisicing elit Deserunt libero voluptate",
        status: true
    });
    const [partner, setPartner] = useState({
        title: "OUR PARTNERS",
        subtitle: "Lorem ipsum dolor sit amet, consectetur adipisicing elit Deserunt libero voluptate",
        status: true
    });
    const [counterBackground, setCounterBackground] = useState(null);
    const [totalRecentPost, setTotalRecentPost] = useState(0);
    const whChooseUsTitle = "WHY CHOOSE US";
    const servicesTitle = "SERVICES";
    const portfolioTitle = "Portfolio";
    const teamTitle = "Team";
    const testimonialTitle = "Testimonial";
    const faqTitle = "FAQ";
    const galleryTitle = "Gallery";
    const recentPostTitle = "Recent Post";
    const partnerTitle = "Partner";
    const counterBackgroundTitle = "Counter Background Photo";
    const totalRecentPostTitle = "Total Recent Post (How many last posts will be shown?)";


    return (
        <>
            <HomePageTabContent
                formData={whyChooseUs}
                setFormData={setWhyChooseUs}
                titleHeader = {whChooseUsTitle}
            />
            <HomePageTabContent
                formData={services}
                setFormData={setServices}
                titleHeader = {servicesTitle}
            />
            <HomePageTabContent
                formData={portfolio}
                setFormData={setPortfolio}
                titleHeader = {portfolioTitle}
            />
            <HomePageTabContent
                formData={team}
                setFormData={setTeam}
                titleHeader = {teamTitle}
            />
            <HomePageTabContent
                formData={testimonial}
                setFormData={setTestimonial}
                titleHeader = {testimonialTitle}
            />
            <HomePageTabContent
                formData={faq}
                setFormData={setFaq}
                titleHeader = {faqTitle}
            />
            <HomePageTabContent
                formData={gallery}
                setFormData={setGallery}
                titleHeader = {galleryTitle}
            />
            <HomePageTabContent
                formData={recentPost}
                setFormData={setRecentPost}
                titleHeader = {recentPostTitle}
            />
            <HomePageTabContent
                formData={partner}
                setFormData={setPartner}
                titleHeader = {partnerTitle}
            />
            <UploadLogoComponent
            logoFile={counterBackground}
            setLogoFile={setCounterBackground}
            title={counterBackgroundTitle}
            />

            <CounterSettingsContent/>
            <HomePageTabContentOneInput
            formData={totalRecentPost}
            setFormData={setTotalRecentPost}
            titleHeader={totalRecentPostTitle}
            />
        </>
    );
};

export default HomePage;
