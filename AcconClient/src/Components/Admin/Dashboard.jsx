import React, {useEffect, useState} from 'react';
import {FaArrowAltCircleRight, FaRegHandPointRight} from "react-icons/fa";
import axios from "axios";
import {normalizeRscURL} from "next/dist/shared/lib/router/utils/app-paths";

const Dashboard = () => {

    const [totalNewsCategories, setTotalNewsCategories] = useState(null);
    const [totalNews, setTotalNews] = useState("");
    const [totalTeamMembers, setTotalTeamMembers] = useState(null);
    const [totalPortfolios, setTotalPortfolios] = useState(null);
    const [totalTestimonials, setTotalTestimonials] = useState(null);
    const [totalSliders, setTotalSliders] = useState(null);

    useEffect(() => {
        const getDashboardData = async () => {
          try{
              const result = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/Cms/GetDashboard`);
              if(result.data.succeeded){
                  var getData = result.data.data;
                  setTotalNewsCategories(getData.totalNewsCategoryCount);
                  setTotalNews(getData.totalNewsCount);
                  setTotalTeamMembers(getData.totalPortfolioCount);
                  setTotalPortfolios(getData.totalPortfolioCount);
                  setTotalTestimonials(getData.totalTestimonialCount);
                  setTotalSliders(getData.totalSliderCount)
              }
          }catch (e){
              console.log(e);
          }
        }
        getDashboardData();
    }, []);

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
                                <span className="info-box__number">{totalNewsCategories}</span>
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
                                <span className="info-box__number">{totalNews}</span>
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
                                <span className="info-box__number">{totalTeamMembers}</span>
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
                                <span className="info-box__number">{totalPortfolios}</span>
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
                                <span className="info-box__number">{totalTestimonials}</span>
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
                                <span className="info-box__number">{totalSliders}</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </>;
};

export default Dashboard;
