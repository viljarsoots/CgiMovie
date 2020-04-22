import React, { Component } from 'react';
import BootstrapTable from 'react-bootstrap-table-next';
import 'react-bootstrap-table-next/dist/react-bootstrap-table2.min.css';
import ToolkitProvider, { Search } from 'react-bootstrap-table2-toolkit';
import 'react-bootstrap-table2-toolkit/dist/react-bootstrap-table2-toolkit.min.css';
import paginationFactory, { PaginationProvider, PaginationListStandalone, SizePerPageDropdownStandalone } from 'react-bootstrap-table2-paginator';
import '@trendmicro/react-modal/dist/react-modal.css';
import Modal from '@trendmicro/react-modal';
import './Home.css';
import { axios, DataUrl } from '../data/Config.js';

const { SearchBar } = Search;


const customTotal = (from, to, size) => (
    <span className="react-bootstrap-table-pagination">
        Showing {from} to {to} of {size} Results
    </span>
);

export class Home extends Component {
    static displayName = Home.name;

	constructor(props) {
		super(props);
		this.state = {
			movieData: [],
			loading: true,
			id: '',
			title: '',
			description: '',
			rating: '',
			category: '',
			year: '',
			openMachineModal: false
		};
		this.componentDidMount = this.componentDidMount.bind(this);
		this.populateMoviesData = this.populateMoviesData.bind(this);
		this.formatProductDetailsButtonCell = this.formatProductDetailsButtonCell.bind(this);
		this.productDetails = this.productDetails.bind(this);
		this.openModal = this.openModal.bind(this);
		this.closeModal = this.closeModal.bind(this);
		this.handeleMovieGet = this.handeleMovieGet.bind(this);

	}
	openModal(id) {
		this.setState({ openModal: true });
		this.handeleMovieGet(id);
	}
	closeModal() {
		this.setState({ openModal: false })
	}

	productDetails = (e) => {

		let { id} = e.target;
		console.log("See Details for Id: " + id);
		this.openModal(id);
	}

	formatProductDetailsButtonCell = (cell, row) => {
		let clickHandler = this.productDetails;
		let emptyContent = React.createElement('i',{id:row.id,onClick:clickHandler});
		let aBtn = React.createElement('a',{id:row.id,className:"btnNtfcdDetails btn-action glyphicons eye_open btn-success", onClick:clickHandler}, emptyContent);
		return aBtn;
	}

	componentDidMount() {
		this.populateMoviesData();
	}

	 populateMoviesData(event) {
		  axios.get(DataUrl)
			.then((response) => {
				this.setState({ movieData: response.data, loading: false });			
				console.log(response.data);
			}).catch((exception) => {
				console.log(exception);
			});
		
	}
	

	handeleMovieGet(id) {
		let e = id + 1;
		this.setState({ 'id': this.state.movieData[e].id });
		this.setState({ 'title': this.state.movieData[e].title });
		this.setState({ 'year': this.state.movieData[e].year });
		this.setState({ 'rating': this.state.movieData[e].rating });
		this.setState({ 'description': this.state.movieData[e].description });
	}

		render(){

		const paginationConfig = {
			custom: true,
			paginationSize: 3,
			pageStartIndex: 1,
			firstPageText: 'First',
			prePageText: 'Back',
			nextPageText: 'Next',
			lastPageText: 'Last',
			nextPageTitle: 'First page',
			prePageTitle: 'Pre page',
			firstPageTitle: 'Next page',
			lastPageTitle: 'Last page',
			showTotal: true,
			paginationTotalRenderer: customTotal,
			sizePerPageList: [{
				text: '10', value: 10
			}, {
				text: '25', value: 25
			}, {
				text: '50', value: 50
			}, {
				text: '100', value: 100
			}, {
				text: 'All', value: this.state.movieData.length
			}] 
		};

		const columns = [{
				dataField: 'id',
				text: 'ID',
				hidden: true

		}, {
				dataField: 'title',
				text: 'Movie Title',
				sort: true
		}, {
				dataField: 'category',
				text: 'Category',
				sort: true

		}, {
				dataField: 'year',
				text: 'Year',
				sort: true
		}, {
				dataField: 'rating',
				text: 'Rating',
				sort: true
		},  {
				dataField: 'action',
				text: '',
				formatter: this.formatProductDetailsButtonCell
		}];

		const contentTable = ({ paginationProps, paginationTableProps }) => {

			return (
				<div className="container">

					<ToolkitProvider
						keyField="id"
						columns={columns}
						data={this.state.movieData}
						search
					>
						{
							(toolkitprops) => {

								return (
									<div>
										{
											this.state.openModal &&
											<Modal size="large" onClose={this.closeModal}>
												<Modal.Header>
													<Modal.Title>
														<h3>Full Movie Data</h3> 
												</Modal.Title>
												</Modal.Header>
												<Modal.Body padding>
													<div className="container">
														<div><h4>{this.state.title}</h4></div>
														<div><h4> Released: {this.state.year} Rating: {this.state.rating}</h4></div>
														<div><h4>Description:</h4></div>
														<div><p>{this.state.description}</p></div>
													</div>
												</Modal.Body>
											</Modal>
										}
										<div className="row">
											<div className="col-sm-8">
											</div>
											<div className="col-sm-4">
												<SearchBar {...toolkitprops.searchProps} />
											</div>
										</div>
										<br />
										<BootstrapTable
											striped
											hover
											{...toolkitprops.baseProps}
											{...paginationTableProps}
										/>

									</div>);


							}
						}
					</ToolkitProvider>
					<div className="row" id="pagination">
						<div className="col-sm">
							<div className="row justify-content-start">
								<SizePerPageDropdownStandalone {...paginationProps} />
							</div>
						</div>
						<div className="col-sm">
							<div className="row justify-content-end">
								<PaginationListStandalone {...paginationProps} />
							</div>
						</div>
					</div>
				</div>
			);
		}


		return (
			<div id="movieTable">
				<h2>MoviesList</h2>

				<PaginationProvider pagination={paginationFactory(paginationConfig)} >
					{contentTable}
				</PaginationProvider>

			</div>
		);


	}
}
