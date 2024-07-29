import React, {useEffect, useState} from 'react';
import {useMediaQuery} from "react-responsive";
import {FaArrowAltCircleRight, FaPlus, FaSortAmountDown} from "react-icons/fa";
import {LazyLoadImage} from "react-lazy-load-image-component";
import {Table, Tbody, Td, Th, Thead, Tr} from "react-super-responsive-table";
import {useRouter} from "next/router";
import axios from "axios";
import {toast} from "react-toastify";

const ViewNews = () => {
    const isMobile = useMediaQuery({ query: '(max-width: 768px)' });

    const router = useRouter();
    const [news, setNews] = useState([]);
    const [tempNews, setTempNews] = useState([]);
    const [loading, setLoading] = useState(true);
    const [keys, setKeys] = useState([]);
    useEffect(() => {
        const fetchSliders = async () => {
            try {
                const response = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/News/GetAllNews`);
                if (response.data.succeeded) {
                    var data = response.data.data.news;
                    setNews(data);
                    const filteredKeys = Object.keys(data[0]).filter(key => key !== "id" && key !== "path");
                    setKeys(filteredKeys);
                }
            } catch (error) {
                console.error('Error fetching news:', error);
            } finally {
                setLoading(false);
            }
        };

        fetchSliders();
    }, []);

    const searchChangeHandler = (value) => {
        if (tempNews.length === 0) {
            setTempNews(news);
        }

        if (value.length > 0) {
            const searchSliders = news.filter(newValue =>
                newValue.title.toLowerCase().includes(value.toLowerCase())
            );

            const exactMatch = searchSliders.filter(newValue =>
                newValue.title.toLowerCase() === value.toLowerCase()
            );
            const otherMatches = searchSliders.filter(newValue =>
                newValue.title.toLowerCase() !== value.toLowerCase()
            );

            setNews([...exactMatch, ...otherMatches]);
        } else {
            setNews(tempNews);
        }
    };
    const deleteClickHandler = async (id) => {
        try {
            const response = await axios.delete(`${process.env.NEXT_PUBLIC_API_URL}/News/DeleteNews?Id=${id}`);
            if (response.data.succeeded) {
                toast.success("Slider deleted successfully")
                setNews(news.filter(newValue => newValue.id !== id));
            }
        } catch (error) {
            console.error('Error deleting slider:', error);
        }
    }
    const editClickHandler = (id) => {
        router.push(`/admin/news/edit/add?Id=${id}`);
    }
    return <>
        <div className="content-wrapper">
            <div className="view-border-header">
                <div className="board-header">
                    <FaArrowAltCircleRight/>
                    <h2>View News</h2>
                </div>
                <div className="view-border-header__add-view"
                        onClick={() => router.push("/admin/news/add")}
                >
                    <FaPlus />
                    <span>Add New</span>
                </div>
            </div>
            <div className="panel-box mt-3">
                <div className="panel-box-body">
                    <div className="slider-show-content">
                        <div className="slider-show-content__counter">
                            <span>Showing entries</span>
                            <select name="slider-show-entries" id="slider-show-entries">
                                <option value="10">10</option>
                                <option value="20">20</option>
                                <option value="50">50</option>
                                <option value="100">100</option>
                            </select>
                        </div>
                        {
                            isMobile && <div className="slider-show-content__sort">
                                <span>Sort:</span>
                                <select name="slider-show-entries" id="slider-show-entries">
                                    <option value="SL">SL</option>
                                    <option value="Heading">Heading</option>
                                    <option value="Title">Category</option>
                                </select>
                            </div>
                        }
                        <div className="slider-show-content__search">
                            <span>Search:</span>
                            <input type="text" placeholder="Search"/>
                        </div>
                    </div>
                    <Table>
                        <Thead>
                            <Tr>
                                <Th>
                                    <div className="slider-table-head">
                                        <span>SL</span>
                                        {!isMobile && <FaSortAmountDown/>}
                                    </div>
                                </Th>
                                <Th>
                                    <div className="slider-table-head">
                                        <span>Photo</span>
                                    </div>
                                </Th>
                                <Th>
                                    <div className="slider-table-head">
                                        <span>Banner</span>
                                    </div>
                                </Th>
                                <Th>
                                    <div className="slider-table-head">
                                        <span>Heading</span>
                                        {!isMobile && <FaSortAmountDown/>}
                                    </div>
                                </Th>
                                <Th>
                                    <div className="slider-table-head">
                                        <span>Category</span>
                                        {!isMobile && <FaSortAmountDown/>}
                                    </div>
                                </Th>
                                <Th>
                                    <div className="slider-table-head">
                                        <span>Action</span>
                                    </div>
                                </Th>
                            </Tr>
                        </Thead>
                        <Tbody>
                            {
                                news?.map((sum,index)=>(
                                    <Tr key={sum.id}>
                                        <Td>
                                            <div className="slider-table-body ">
                                                {index + 1}
                                            </div>
                                        </Td>
                                        <Td>
                                            <LazyLoadImage
                                                src={`/${sum.photo}`}
                                                alt={sum.photo}
                                                className="slider-table-image"
                                            />
                                        </Td>
                                        <Td>
                                            <LazyLoadImage
                                                src={`/${sum.banner}`}
                                                alt={sum.banner}
                                                className="slider-table-banner-image"
                                            />
                                        </Td>
                                        <Td >
                                            <div className="slider-table-body ">
                                                {sum.title}
                                            </div>
                                        </Td>
                                        <Td >
                                            <div className="slider-table-body ">
                                                {sum.category}
                                            </div>
                                        </Td>
                                        <Td>
                                            <div className="action-edit slider-table-body">
                                                <button className="btn btn-warning me-2"
                                                        onClick={() => editClickHandler(sum.id)}
                                                >Edit</button>
                                                <button className="btn btn-danger"
                                                        onClick={() => deleteClickHandler(sum.id)}
                                                >Delete</button>
                                            </div>
                                        </Td>
                                    </Tr>
                                ))
                            }
                        </Tbody>
                    </Table>
                    <div className="pagination-section">
                        <div className="pagination-information">
                            <span>Showing </span>
                            <span>1</span>
                            <span>to</span>
                            <span>2</span>
                            <span>of</span>
                            <span>2</span>
                            <span>entries</span>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </>
};

export default ViewNews;
