import React, {useEffect, useState} from 'react';
import HomePageTabContent from "@/Components/Ui/HomePageComponent/HomePageTabContent";
import UploadLogoComponent from "@/Components/Ui/UploadLogoComponent";
import CounterSettingsContent from "@/Components/Ui/HomePageComponent/CounterSettingsContent";
import {toast} from "react-toastify";
import axios from "axios";
import {HomePageSettingsEnum} from "@/data/enum/HomePageSettingsEnum";

const HomePage = () => {
    const [whyChooseUs, setWhyChooseUs] = useState({
        title: "",
        subtitle: "",
        status: true
    });
    const [services, setServices] = useState({
        title: "",
        subtitle: "",
        status: true
    });
    const [portfolio, setPortfolio] = useState({
        title: "",
        subtitle: "",
        status: true
    });
    const [team, setTeam] = useState({
        title: "",
        subtitle: "",
        status: true
    });
    const [testimonial, setTestimonial] = useState({
        title: "",
        subtitle: "",
        status: true
    });
    const [faq, setFaq] = useState({
        title: "",
        subtitle: "",
        status: true
    });
    const [gallery, setGallery] = useState({
        title: "",
        subtitle: "",
        status: true
    });
    const [recentPost, setRecentPost] = useState({
        title: "",
        subtitle: "",
        status: true,
        recentPost: 0
    });
    const [partner, setPartner] = useState({
        title: "",
        subtitle: "",
        status: true
    });
    const [counterSettings, setCounterSettings] = useState({
        counter1Text: "",
        counter1Value: "",
        counter2Text: "",
        counter2Value: "",
        counter3Text: "",
        counter3Value: "",
        counter4Text: "",
        counter4Value: "",
        status: true
    });

    const [counterBackground, setCounterBackground] = useState(null);
    const [existCounterBackground, setExistCounterBackground] = useState(null);
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

    useEffect(() => {
        const getHomePageSettings = async () => {
            const homeSettings = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/Settings/GetHomePageSettings`);
            if(homeSettings.data.succeeded){
                const homeSettingsData = homeSettings.data.data;
                setWhyChooseUs({
                    title: homeSettingsData.whyChooseUs.title,
                    subtitle: homeSettingsData.whyChooseUs.subTitle,
                    status: homeSettingsData.whyChooseUs.status
                });
                setServices({
                    title: homeSettingsData.services.title,
                    subtitle: homeSettingsData.services.subTitle,
                    status: homeSettingsData.services.status
                });
                setPortfolio({
                    title: homeSettingsData.portfolio.title,
                    subtitle: homeSettingsData.portfolio.subTitle,
                    status: homeSettingsData.portfolio.status
                });
                setTeam({
                    title: homeSettingsData.team.title,
                    subtitle: homeSettingsData.team.subTitle,
                    status: homeSettingsData.team.status
                });
                setTestimonial({
                    title: homeSettingsData.testimonial.title,
                    subtitle: homeSettingsData.testimonial.subTitle,
                    status: homeSettingsData.testimonial.status
                });
                setFaq({
                    title: homeSettingsData.faq.title,
                    subtitle: homeSettingsData.faq.subTitle,
                    status: homeSettingsData.faq.status
                });
                setGallery({
                    title: homeSettingsData.gallery.title,
                    subtitle: homeSettingsData.gallery.subTitle,
                    status: homeSettingsData.gallery.status
                });
                setRecentPost({
                    title: homeSettingsData.recentPost.title,
                    subtitle: homeSettingsData.recentPost.subTitle,
                    status: homeSettingsData.recentPost.status,
                    recentPost: homeSettingsData.recentPost.recentPostCount
                });
                setPartner({
                    title: homeSettingsData.partner.title,
                    subtitle: homeSettingsData.partner.subTitle,
                    status: homeSettingsData.partner.status
                });
                setCounterSettings({
                    counter1Text: homeSettingsData.counterSettings.counter1Text,
                    counter1Value: homeSettingsData.counterSettings.counter1Value,
                    counter2Text: homeSettingsData.counterSettings.counter2Text,
                    counter2Value: homeSettingsData.counterSettings.counter2Value,
                    counter3Text: homeSettingsData.counterSettings.counter3Text,
                    counter3Value: homeSettingsData.counterSettings.counter3Value,
                    counter4Text: homeSettingsData.counterSettings.counter4Text,
                    counter4Value: homeSettingsData.counterSettings.counter4Value,
                    status: homeSettingsData.counterSettings.status
                });
                setExistCounterBackground(`/${homeSettingsData.counterBackgroundImage}`);

            }
        }
        getHomePageSettings();
    }, []);


    const handleWhyChooseUs = async () => {
        const data = {
            settingId: HomePageSettingsEnum.WhyChooseUs,
            title: whyChooseUs.title,
            subtitle: whyChooseUs.subtitle,
            status: whyChooseUs.status
        }
        const result = await axios.post(`${process.env.NEXT_PUBLIC_API_URL}/Settings/UpdateHomePageSettings`, data);

        if (result.data.succeeded) {
            toast.success("Why Choose Us updated successfully")
        } else {
            toast.error("An error occurred while updating Why Choose Us")
        }
    }
    const handleService = async () => {
        const data = {
            settingId: HomePageSettingsEnum.Service,
            title: services.title,
            subtitle: services.subtitle,
            status: services.status
        }
        const result = await axios.post(`${process.env.NEXT_PUBLIC_API_URL}/Settings/UpdateHomePageSettings`, data);

        if (result.data.succeeded) {
            toast.success("Services updated successfully")
        } else {
            toast.error("An error occurred while updating Services")
        }
    }
    const handlePortfolio = async () => {
        const data = {
            settingId: HomePageSettingsEnum.Portfolio,
            title: portfolio.title,
            subtitle: portfolio.subtitle,
            status: portfolio.status
        }
        const result = await axios.post(`${process.env.NEXT_PUBLIC_API_URL}/Settings/UpdateHomePageSettings`, data);

        if (result.data.succeeded) {
            toast.success("Portfolio updated successfully")
        } else {
            toast.error("An error occurred while updating Portfolio")
        }
    }
    const handleTeam = async () => {
        const data = {
            settingId: HomePageSettingsEnum.Team,
            title: team.title,
            subtitle: team.subtitle,
            status: team.status
        }
        const result = await axios.post(`${process.env.NEXT_PUBLIC_API_URL}/Settings/UpdateHomePageSettings`, data);

        if (result.data.succeeded) {
            toast.success("Team updated successfully")
        } else {
            toast.error("An error occurred while updating Team")
        }
    }
    const handleTestimoinal = async () => {
        const data = {
            settingId: HomePageSettingsEnum.Testimonial,
            title: testimonial.title,
            subtitle: testimonial.subtitle,
            status: testimonial.status
        }
        const result = await axios.post(`${process.env.NEXT_PUBLIC_API_URL}/Settings/UpdateHomePageSettings`, data);

        if (result.data.succeeded) {
            toast.success("Testimonial updated successfully")
        } else {
            toast.error("An error occurred while updating Testimonial")
        }
    }
    const handleFaq = async () => {
        const data = {
            settingId: HomePageSettingsEnum.Faq,
            title: faq.title,
            subtitle: faq.subtitle,
            status: faq.status
        }
        const result = await axios.post(`${process.env.NEXT_PUBLIC_API_URL}/Settings/UpdateHomePageSettings`, data);

        if (result.data.succeeded) {
            toast.success("FAQ updated successfully")
        } else {
            toast.error("An error occurred while updating FAQ")
        }
    }
    const handleGallery = async () => {
        const data = {
            settingId: HomePageSettingsEnum.Gallery,
            title: gallery.title,
            subtitle: gallery.subtitle,
            status: gallery.status
        }
        const result = await axios.post(`${process.env.NEXT_PUBLIC_API_URL}/Settings/UpdateHomePageSettings`, data);

        if (result.data.succeeded) {
            toast.success("Gallery updated successfully")
        } else {
            toast.error("An error occurred while updating Gallery")
        }
    }
    const handleRecentPost = async () => {
        const data = {
            settingId: HomePageSettingsEnum.RecentPost,
            title: recentPost.title,
            subtitle: recentPost.subtitle,
            status: recentPost.status,
            TotalRecentPosts: recentPost.recentPost
        }
        const result = await axios.post(`${process.env.NEXT_PUBLIC_API_URL}/Settings/UpdateHomePageSettings`, data);

        if (result.data.succeeded) {
            toast.success("Recent Post updated successfully")
        } else {
            toast.error("An error occurred while updating Recent Post")
        }
    }
    const handlePartner = async () => {
        const data = {
            settingId: HomePageSettingsEnum.Partner,
            title: partner.title,
            subtitle: partner.subtitle,
            status: partner.status
        }
        const result = await axios.post(`${process.env.NEXT_PUBLIC_API_URL}/Settings/UpdateHomePageSettings`, data);

        if (result.data.succeeded) {
            toast.success("Partner updated successfully")
        } else {
            toast.error("An error occurred while updating Partner")
        }
    }

    const handleCounterSettings = async () => {
        const data = {
            settingId: HomePageSettingsEnum.CounterSettings,
            Counter1Text: counterSettings.counter1Text,
            Counter1Value: counterSettings.counter1Value,
            Counter2Text: counterSettings.counter2Text,
            Counter2Value: counterSettings.counter2Value,
            Counter3Text: counterSettings.counter3Text,
            Counter3Value: counterSettings.counter3Value,
            Counter4Text: counterSettings.counter4Text,
            Counter4Value: counterSettings.counter4Value,
            Status: Boolean(counterSettings.status)
        }
        console.log("data", data)
        const result = await axios.post(`${process.env.NEXT_PUBLIC_API_URL}/Settings/UpdateHomePageSettings`, data);
        if (result.data.succeeded) {
            toast.success("Counter Settings updated successfully");
        } else {
            toast.error("An error occurred while updating Counter Settings");
        }
    }

    const handleCounterImage = async () => {
        const formData = new FormData();
        formData.append("CounterBackgroundPhoto", counterBackground);
        formData.append("settingId", HomePageSettingsEnum.CounterBackgroundPhoto)
        formData.append("status",true);
        const result = await axios.post(`${process.env.NEXT_PUBLIC_API_URL}/Settings/GetHomePageSettingsImage`, formData);
        if (result.data.succeeded) {
            toast.success("Counter Background updated successfully");
            setExistCounterBackground(result.data.data.photo)
        } else {
            toast.error("An error occurred while updating Counter Background");
        }
    }

    return (
        <>
            <HomePageTabContent
                formData={whyChooseUs}
                setFormData={setWhyChooseUs}
                titleHeader={whChooseUsTitle}
                handleSubmit={handleWhyChooseUs}
            />
            <HomePageTabContent
                formData={services}
                setFormData={setServices}
                titleHeader={servicesTitle}
                handleSubmit={handleService}
            />
            <HomePageTabContent
                formData={portfolio}
                setFormData={setPortfolio}
                titleHeader={portfolioTitle}
                handleSubmit={handlePortfolio}
            />
            <HomePageTabContent
                formData={team}
                setFormData={setTeam}
                titleHeader={teamTitle}
                handleSubmit={handleTeam}
            />
            <HomePageTabContent
                formData={testimonial}
                setFormData={setTestimonial}
                titleHeader={testimonialTitle}
                handleSubmit={handleTestimoinal}
            />
            <HomePageTabContent
                formData={faq}
                setFormData={setFaq}
                titleHeader={faqTitle}
                handleSubmit={handleFaq}
            />
            <HomePageTabContent
                formData={gallery}
                setFormData={setGallery}
                titleHeader={galleryTitle}
                handleSubmit={handleGallery}
            />
            <HomePageTabContent
                formData={recentPost}
                setFormData={setRecentPost}
                titleHeader={recentPostTitle}
                handleSubmit={handleRecentPost}
            />
            <HomePageTabContent
                formData={partner}
                setFormData={setPartner}
                titleHeader={partnerTitle}
                handleSubmit={handlePartner}
            />
            <UploadLogoComponent
                logoFile={counterBackground}
                setLogoFile={setCounterBackground}
                title={counterBackgroundTitle}
                existPhoto={existCounterBackground}
                handleSubmitLogo={handleCounterImage}
            />

            <CounterSettingsContent
                formData={counterSettings}
                setFormData={setCounterSettings}
                handleSubmit={handleCounterSettings}
            />
        </>
    );
};

export default HomePage;
