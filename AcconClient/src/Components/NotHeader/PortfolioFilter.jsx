import React, { useState } from 'react';
import Card from "@/Components/Card/Card";
import { portFolioJson, category } from "@/data/portFolioJson";

const PortfolioFilter = () => {
    const [portfolio, setPortfolio] = useState(portFolioJson);
    const [activeCategory, setActiveCategory] = useState("All");

    const filterPortfolio = (category) => {
        setActiveCategory(category);
        if (category === "All") {
            setPortfolio(portFolioJson);
        } else {
            const filteredPortfolio = portFolioJson.filter(item => item.category === category);
            setPortfolio(filteredPortfolio);
        }
    };

    return (
        <>
            <div>
                <div className="portfolio-filter">
                    <ul>
                        {category?.map((item, index) =>
                            <li
                                key={index}
                                onClick={() => filterPortfolio(item)}
                                className={activeCategory === item ? 'active' : ''}
                            >
                                {item}
                            </li>
                        )}
                    </ul>
                </div>
            </div>
            <div className="row">
                {portfolio?.map((item, index) =>
                    <div key={index} className="col-md-4 col-sm-6 col-xs-12 clear-three">
                        <Card data={item} baseUrl={"portfolio"}/>
                    </div>
                )}
            </div>
        </>
    );
};

export default PortfolioFilter;
