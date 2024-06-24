import React from 'react';
import {FaCaretLeft, FaCaretRight} from "react-icons/fa";
import Slider from "react-slick";
import CardPartner from "@/Components/Card/CardPartner";
function SampleNextArrow(props) {
    const { className, onClick } = props;
    return (
        <div onClick={onClick} className={`arrow ${className}`}>
            <FaCaretRight className="arrows"/>
        </div>
    );
}

function SamplePrevArrow(props) {
    const {className, onClick} = props;
    return (
        <div onClick={onClick} className={`arrow ${className}`}>
            <FaCaretLeft className="arrows"/>
        </div>
    );
}
const SliderPartners = ({data}) => {
    const settings = {
        dots: false,
        lazyLoad: true,
        infinite: true,
        speed: 500,
        slidesToShow: 5,
        slidesToScroll: 1,
        initialSlide: 0,
        nextArrow: <SampleNextArrow />,
        prevArrow: <SamplePrevArrow />,
        responsive: [
            {
                breakpoint: 1024,
                settings: {
                    slidesToShow: 4,
                    slidesToScroll: 4,
                }
            },
            {
                breakpoint: 768,
                settings: {
                    slidesToShow: 3,
                    slidesToScroll: 3,
                }
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 2,
                    initialSlide: 1
                }
            }
        ]
    };
    return (
        <div>
            <div className="slider-partner">
                <div className="slider-container">
                    <Slider {...settings}>
                        {data.map((item, index) => {
                            return <CardPartner key={index} data={item}/>
                        })}
                    </Slider>
                </div>
            </div>
        </div>
    );
};

export default SliderPartners;
