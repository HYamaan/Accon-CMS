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

const HomePage = () => {
    return (
        <main>

            <SliderComponent />
            <ChooseUs />
            <Services />
            <PortFolio />
            <Experience />
            <TestimonialArea />
            <Faq />
            <CounterupArea />
            <PhotoGallery />
            <RecentPost />
            <Partners />
        </main>
    );
};

export default HomePage;


