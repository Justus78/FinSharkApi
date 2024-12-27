
type Props = {
    config: any;
    data : any;
}

const RatioList = ({config, data}: Props) => {
    const renderedRow = config.map( (row: any) => {
        return (
            <li className='py-6 sm:py-6'>
                <div className="flex items-center space-x-4">
                    <div className="flex-1 min-w-0">
                        <p className="text-sm font-medium text-gray-900 truncate">
                            {row.label ? row.label : "No Label"}
                        </p>
                        <p className="text-sm text-gray-500 truncate">
                            {row.subTitle && row.subTitle}
                        </p>
                    </div>
                    <div className="inline-flex items-center text-base font-semibold text-gray-900">
                        {row.render(data)}
                    </div>
                </div>
            </li>
        )
    })
  return (
    <div className='gb-white shadow rounded-lg ml-4 mt-4 mb-4 p-4 sm:p-6 h-full'>
        <ul className='divide-y divided-gray-200'>
            {renderedRow}
        </ul>

    </div>
  )
}

export default RatioList