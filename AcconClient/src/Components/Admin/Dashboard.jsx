import React from 'react';
import {FaArrowAltCircleRight, FaRegHandPointRight} from "react-icons/fa";

const Dashboard = () => {
    return <>
        <div className="content-wrapper">
            <div className="board-header">
                <FaArrowAltCircleRight/>
                <h2>Dashboard</h2>
            </div>
            <div className="content">
                <div className="row">
                    <div className="col-md-4 col-xs-12">
                        <div className="info-box">
                            <div className="info-box__icon">
                                <FaRegHandPointRight/>
                            </div>
                            <div className="info-box__content">
                                <span className="info-box__text">TOTAL NEWS CATEGORIES</span>
                                <span className="info-box__number">6</span>
                            </div>
                        </div>
                    </div>
                    <div className="col-md-4 col-xs-12">
                        <div className="info-box">
                            <div className="info-box__icon">
                                <FaRegHandPointRight/>
                            </div>
                            <div className="info-box__content">
                                <span className="info-box__text">TOTAL NEWS</span>
                                <span className="info-box__number">6</span>
                            </div>
                        </div>
                    </div>
                    <div className="col-md-4 col-xs-12">
                        <div className="info-box">
                            <div className="info-box__icon">
                                <FaRegHandPointRight/>
                            </div>
                            <div className="info-box__content">
                                <span className="info-box__text">Total Team Members</span>
                                <span className="info-box__number">5</span>
                            </div>
                        </div>
                    </div>
                    <div className="col-md-4 col-xs-12">
                        <div className="info-box">
                            <div className="info-box__icon">
                                <FaRegHandPointRight/>
                            </div>
                            <div className="info-box__content">
                                <span className="info-box__text">TOTAL PORTFOLIOS</span>
                                <span className="info-box__number">6</span>
                            </div>
                        </div>
                    </div>
                    <div className="col-md-4 col-xs-12">
                        <div className="info-box">
                            <div className="info-box__icon">
                                <FaRegHandPointRight/>
                            </div>
                            <div className="info-box__content">
                                <span className="info-box__text">TOTAL TESTIMONIALS</span>
                                <span className="info-box__number">4</span>
                            </div>
                        </div>
                    </div>
                    <div className="col-md-4 col-xs-12">
                        <div className="info-box">
                            <div className="info-box__icon">
                                <FaRegHandPointRight/>
                            </div>
                            <div className="info-box__content">
                                <span className="info-box__text">TOTAL SLIDERS</span>
                                <span className="info-box__number">2</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </>;
};

export default Dashboard;
