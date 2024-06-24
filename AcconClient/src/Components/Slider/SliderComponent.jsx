import React, {useState} from "react";
import Slider from "react-slick";
import {LazyLoadImage} from "react-lazy-load-image-component";
import {useRouter} from "next/router";
import {sliderData} from "@/data/homeSliderJson";

function SampleNextArrow(props) {
    const {className, style, onClick} = props;
    return (
        <div
            className={className}
            style={{
                ...style,
                display: "block",
                position: "absolute",
                top: "50%",
                right: "3rem",
                transform: "translate(0, -50%)",
                zIndex: "100",
                cursor: "pointer"
            }}
            onClick={onClick}
        />
    );
}

function SamplePrevArrow(props) {
    const {className, style, onClick} = props;
    return (
        <div
            className={`${className}`}
            style={{
                ...style,
                display: "block",
                position: "absolute",
                top: "50%",
                left: "1.5rem",
                transform: "translate(0, -50%)",
                zIndex: "100",
                cursor: "pointer"
            }}
            onClick={onClick}
        />
    );
}

const SliderComponent = () => {
    const router = useRouter();
    const [currentSlide, setCurrentSlide] = useState(0);

    const settings = {
        dots: false,
        lazyLoad: true,
        infinite: true,
        speed: 500,
        slidesToShow: 1,
        slidesToScroll: 1,
        initialSlide: 0,
        className: "main-slider",
        nextArrow: <SampleNextArrow/>,
        prevArrow: <SamplePrevArrow/>,
        afterChange: (current) => {
            setCurrentSlide(current);
        }
    };

    const getAnimateClass = (index) => (currentSlide === index ? "animate" : "");

    return (
        <div className="slider-section">
            <div className="slider-container">
                <Slider {...settings}>
                    {sliderData.map((slide, index) => (
                        <div key={index} className="slider-section">
                            <LazyLoadImage src={slide.src} alt={slide.alt} />
                            <div className={`slider-text ${getAnimateClass(index)}`}>
                                <h3>{slide.title}</h3>
                                <p>{slide.description}</p>
                                <div className="d-flex gap-3 justify-content-center">
                                    <button
                                        className="primary-button"
                                        onClick={() => router.push(slide.primaryButton.link)}
                                    >
                                        {slide.primaryButton.text}
                                    </button>
                                    <button
                                        className="secondary-button"
                                        onClick={() => router.push(slide.secondaryButton.link)}
                                    >
                                        {slide.secondaryButton.text}
                                    </button>
                                </div>
                            </div>
                        </div>
                    ))}
                </Slider>
            </div>
        </div>
    );
};

export default SliderComponent;
