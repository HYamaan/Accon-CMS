import React from 'react';
import Head from 'next/head';
import SliderComponent from "@/Components/Slider/SliderComponent";
import ChooseUs from "@/Components/HomePageComponent/ChooseUs";
import Services from "@/Components/HomePageComponent/Services";
import PortFolio from "@/Components/HomePageComponent/PortFolio";
import Experience from "@/Components/HomePageComponent/Experience";
import TestimonialArea from "@/Components/HomePageComponent/TestimonialArea";
import PhotoGallery from "@/Components/HomePageComponent/PhotoGallery";
import CounterupArea from "@/Components/HomePageComponent/CounterupArea";
import Faq from "@/Components/HomePageComponent/FAQ";
import RecentPost from "@/Components/HomePageComponent/RecentPost";
import Partners from "@/Components/HomePageComponent/Partners";
import axios from "axios";

const HomePage = ({data}) => {
    return (
        <main>
            <SliderComponent  slider={data.sliders}/>
            <ChooseUs whyChooseUs={data.whyChooseUs}/>
            <Services services={data.services}/>
            <PortFolio portfolios={data.portfolio}/>
            <Experience teams={data.teamMembers}/>
            <TestimonialArea testimonials={data.testimonials}/>
            <Faq faqData={data.faqs}/>
            <CounterupArea counterSection={data.counterSection}/>
            <PhotoGallery galleries={data.galleries}/>
            <RecentPost news={data.news}/>
            <Partners partners={data.partners}/>
        </main>
    );
};

export default HomePage;
