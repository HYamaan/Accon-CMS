import React from 'react';
import Slider from "react-slick";
import CardTestimonial from "@/Components/Card/CardTestimonial";

const SliderTestimonialArea = ({data}) => {
    const settings = {
        dots: true,
        lazyLoad: true,
        infinite: false,
        speed: 500,
        slidesToShow: 3,
        slidesToScroll: 1,
        initialSlide: 0,
        dotsClass: "slick-dots",
        arrows: false,
        responsive: [
            {
                breakpoint: 1024,
                settings: {
                    slidesToShow: 3,
                    slidesToScroll: 3,
                }
            },
            {
                breakpoint: 768,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 2,
                }
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                }
            }
        ]
    };

    return (
        <div className="slider-team">
            <div className="slider-container">
                <Slider {...settings}>
                    {data.map((item, index) => (
                        <CardTestimonial
                            key={index}
                           data={item}
                        />
                    ))}
                </Slider>
            </div>
        </div>

    );
};

export default SliderTestimonialArea;
