import React, { Component } from 'react';
import BootstrapTable from 'react-bootstrap-table-next';
import 'react-bootstrap-table-next/dist/react-bootstrap-table2.min.css';
import ToolkitProvider, { Search } from 'react-bootstrap-table2-toolkit';
import 'react-bootstrap-table2-toolkit/dist/react-bootstrap-table2-toolkit.min.css';
import paginationFactory, { PaginationProvider, PaginationListStandalone, SizePerPageDropdownStandalone } from 'react-bootstrap-table2-paginator';
import './Home.css';

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
            movieData: []
        };

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
			}] // A numeric array is also available. the purpose of above example is custom the text
		};

		const columns = [{
			dataField: 'id',
			text: 'ID',

		}, {
			dataField: 'machineName',
			text: 'Machine Name',

		}, {
			dataField: 'producerName',
			text: 'Producer Name',

		}, {
			dataField: 'installDate',
			text: 'Install Date'
		}, {
			dataField: 'nrOfMaitn',
			text: 'Number of maitenences'
		}, {
			dataField: 'location',
			text: 'Location'
		}, {
			dataField: 'lastMtnDate',
			text: 'Last Maitenence Date'
		}, {
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
										<div className="row">
											<div className="col-sm-8">
											</div>
											<div className="col-sm-4">
												<SearchBar {...toolkitprops.searchProps} />
											</div>
										</div>
										<br />
										<button type="button" className="btn btn-secondary" onClick={this.handeleAddMachine}>Add New Machine</button>
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
			<div id="machineTable">
				<h2>Machine Table</h2>

				<PaginationProvider pagination={paginationFactory(paginationConfig)} >
					{contentTable}
				</PaginationProvider>

			</div>
		);


	}
}
