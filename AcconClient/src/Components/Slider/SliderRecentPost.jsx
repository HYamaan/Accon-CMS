import React from 'react';
import {FaCaretLeft, FaCaretRight} from "react-icons/fa";
import Slider from "react-slick";
import RecentPostCard from "@/Components/Card/RecentPostCard";

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
const SliderRecentPost = ({data}) => {
    const settings = {
        dots: false,
        lazyLoad: true,
        infinite: true,
        speed: 500,
        slidesToShow: 3,
        slidesToScroll: 1,
        initialSlide: 0,
        nextArrow: <SampleNextArrow />,
        prevArrow: <SamplePrevArrow />,
        responsive: [
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
        <div>
            <div className="slider-recent-post">
                <div className="slider-container">
                    <Slider {...settings}>
                        {data.map((item, index) => {
                            return <RecentPostCard key={index} data={item}/>
                        })}
                    </Slider>
                </div>
            </div>
        </div>
    );
};

export default SliderRecentPost;
