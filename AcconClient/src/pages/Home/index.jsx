import React, {memo, useEffect} from 'react';
import dynamic from 'next/dynamic';

const SliderComponent = dynamic(() => import("@/Components/Slider/SliderComponent"));
const ChooseUs = dynamic(() => import("@/Components/HomePageComponent/ChooseUs"));
const Services = dynamic(() => import("@/Components/HomePageComponent/Services"));
const PortFolio = dynamic(() => import("@/Components/HomePageComponent/PortFolio"));
const Experience = dynamic(() => import("@/Components/HomePageComponent/Experience"));
const TestimonialArea = dynamic(() => import("@/Components/HomePageComponent/TestimonialArea"));
const PhotoGallery = dynamic(() => import("@/Components/HomePageComponent/PhotoGallery"));
const CounterupArea = dynamic(() => import("@/Components/HomePageComponent/CounterupArea"));
const Faq = dynamic(() => import("@/Components/HomePageComponent/FAQ"));
const RecentPost = dynamic(() => import("@/Components/HomePageComponent/RecentPost"));
const Partners = dynamic(() => import("@/Components/HomePageComponent/Partners"));

const HomePage = ({ data }) => {

    return (
        <main>
            {data.sliders && <SliderComponent slider={data.sliders} />}
            {data.whyChooseUs && <ChooseUs whyChooseUs={data.whyChooseUs} />}
            {data.services && <Services services={data.services} />}
            {data.portfolio && <PortFolio portfolios={data.portfolio} />}
            {data.teamMembers && <Experience teams={data.teamMembers} />}
            {data.testimonials && <TestimonialArea testimonials={data.testimonials} />}
            {data.faqs && <Faq faqData={data.faqs} />}
            {data.counterSection && <CounterupArea counterSection={data.counterSection} />}
            {data.galleries && <PhotoGallery galleries={data.galleries} />}
            {data.news && <RecentPost news={data.news} />}
            {data.partners && <Partners partners={data.partners} />}
        </main>
    );
};

export default HomePage;
