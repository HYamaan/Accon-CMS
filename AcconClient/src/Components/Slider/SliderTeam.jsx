import React from 'react';
import Slider from "react-slick";
import CardTeam from "@/Components/Card/CardTeam";
import {FaCaretLeft, FaCaretRight} from "react-icons/fa";
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

const SliderTeam = ({data}) => {

    const settings = {
        dots: false,
        lazyLoad: true,
        infinite: true,
        speed: 500,
        slidesToShow: 4,
        slidesToScroll: 1,
        initialSlide: 0,
        nextArrow: <SampleNextArrow />,
        prevArrow: <SamplePrevArrow />,
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
                        <CardTeam key={index} data={item}/>
                    ))}
                </Slider>
            </div>
        </div>

    );
};

export default SliderTeam;
