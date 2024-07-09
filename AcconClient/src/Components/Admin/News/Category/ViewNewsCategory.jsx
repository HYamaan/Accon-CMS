import React, {useEffect, useState} from 'react';
import {useMediaQuery} from "react-responsive";
import {FaArrowAltCircleRight, FaPlus, FaSortAmountDown} from "react-icons/fa";
import {Table, Tbody, Td, Th, Thead, Tr} from "react-super-responsive-table";
import axios from "axios";
import {toast} from "react-toastify";
import {useRouter} from "next/router";

const ViewNewsCategory = () => {
    const isMobile = useMediaQuery({ query: '(max-width: 768px)' ,});
    const router = useRouter();
    const [newsCategory, setNewsCategory] = useState([]);
    const [tempNewsCategory, setTempNewsCategory] = useState([]);
    const [loading, setLoading] = useState(true);
    const [keys, setKeys] = useState([]);

    useEffect(() => {
        const fetchSliders = async () => {
            try {
                const response = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/News/GetAllNewsCategory`);
                if (response.data.succeeded) {
                    var data = response.data.data.newsCategories;
                    setNewsCategory(data);
                    const filteredKeys = Object.keys(data[0]).filter(key => key !== "id" && key !== "path");
                    setKeys(filteredKeys);
                    setLoading(false);
                }
            } catch (error) {
                setLoading(false);
                console.error('Error fetching sliders:', error);
            } finally {
                setLoading(false);
            }
        };
        fetchSliders();
    }, []);

    const handleSortChange = (event) => {
        const value = event.target.value;

        const sortedCategory = newsCategory.sort((a, b) => {
            const textA = a[value].toLowerCase();
            const textB = b[value].toLowerCase();
            return textA > textB ? -1 : textA < textB ? 1 : 0;
        });
        setNewsCategory( [...sortedCategory]);
    }
    const editClickHandler = (id) => {
        router.push(`/admin/news-category/edit/add?Id=${id}`);
    }
    const searchChangeHandler = (value) => {
        if (tempNewsCategory.length === 0) {
            setTempNewsCategory(newsCategory);
        }

        if (value.length > 0) {
            const searchSliders = tempNewsCategory.filter(category =>
                category.title.toLowerCase().includes(value.toLowerCase())
            );

            const exactMatch = searchSliders.filter(category =>
                category.title.toLowerCase() === value.toLowerCase()
            );
            const otherMatches = searchSliders.filter(category =>
                category.title.toLowerCase() !== value.toLowerCase()
            );

            setNewsCategory([...exactMatch, ...otherMatches]);
        } else {
            setNewsCategory(tempNewsCategory);
        }
    };

    const deleteClickHandler = async (id) => {
        try {
            const response = await axios.delete(`${process.env.NEXT_PUBLIC_API_URL}/News/DeleteNewsCategory?Id=${id}`);
            if (response.data.succeeded) {
                toast.success("Category deleted successfully")
                setNewsCategory(newsCategory.filter(category => category.id !== id));
            }
        } catch (error) {
            console.error('Error deleting category:', error);
        }
    }

    if (loading) {
        return (
            <div className="content-wrapper">
                <div>Loading...</div>
            </div>
        );
    }

    return <>
        <div className="content-wrapper">
            <div className="view-border-header">
                <div className="board-header">
                    <FaArrowAltCircleRight/>
                    <h2>View News Categories</h2>
                </div>
                <div className="view-border-header__add-view"
                onClick={() => router.push("/admin/news-category/add")}
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
                                    <option value="FaqTitle">FAQ Title</option>
                                    <option value="ShowOnHome">Show On Home ?</option>
                                </select>
                            </div>
                        }
                        <div className="slider-show-content__search">
                            <span>Search:</span>
                            <input type="text" placeholder="Search"
                                      onChange={(event) => searchChangeHandler(event.target.value)}
                            />
                        </div>
                    </div>
                    <Table>
                        <Thead>
                            <Tr>
                                <Th className="w-25">
                                    <div className="slider-table-head">
                                        <span>SL</span>
                                        {!isMobile && <FaSortAmountDown/>}
                                    </div>
                                </Th>
                                <Th className="table-body-col-header-45">
                                    <div className="slider-table-head">
                                        <span>Category Name</span>
                                        {!isMobile && <FaSortAmountDown/>}
                                    </div>
                                </Th>
                                <Th className="w-25">
                                    <div className="slider-table-head">
                                        <span>Action</span>
                                    </div>
                                </Th>
                            </Tr>
                        </Thead>
                        <Tbody>
                            {
                                newsCategory?.map((sum, index) => (
                                    <Tr key={sum.id}>
                                        <Td>
                                            <div className="slider-table-body ">
                                                {index + 1}
                                            </div>
                                        </Td>
                                        <Td>
                                            <div className="slider-table-body ">
                                                {sum.title}
                                            </div>

                                        </Td>
                                        <Td>
                                            <div className="action-edit slider-table-body">
                                                <button className="btn btn-warning me-2"
                                                        onClick={() => editClickHandler(sum.id)}>Edit
                                                    </button>
                                                <button className="btn btn-danger"
                                                        onClick={() => deleteClickHandler(sum.id)}>Delete
                                                </button>
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

export default ViewNewsCategory;
