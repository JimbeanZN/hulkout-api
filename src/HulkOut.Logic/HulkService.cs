﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HulkOut.Shared.Interfaces.Hulk;
using HulkOut.Shared.Models.Data;

namespace HulkOut.Logic
{
	/// <summary>
	/// 
	/// </summary>
	/// <seealso cref="IHulkService" />
	public class HulkService : IHulkService
	{
		private readonly IHulkRepository _hulkRepository;

		public HulkService(IHulkRepository hulkRepository)
		{
			_hulkRepository = hulkRepository;
		}

		/// <summary>
		/// Gets the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public async Task<Hulk> Get(Guid id)
		{
			var result = await GetAll(model => model.Id == id);	
			return result.FirstOrDefault();
		}

		/// <summary>
		/// Gets all.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException">filter</exception>
		public async Task<IEnumerable<Hulk>> GetAll(Expression<Func<Hulk, bool>> filter)
		{
			if (filter == null)
				throw new ArgumentNullException(nameof(filter));

			return await _hulkRepository.Get(filter);
		}

		/// <summary>
		/// Inserts the specified model.
		/// </summary>
		/// <param name="model">The model.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException">model</exception>
		public async Task<Hulk> Insert(Hulk model)
		{
			if (model == null)
				throw new ArgumentNullException(nameof(model));

			return await _hulkRepository.Insert(model);
		}

		/// <summary>
		/// Updates the specified model.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="model">The model.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException">model</exception>
		public async Task<Hulk> Update(Guid id, Hulk model)
		{
			if (model == null)
				throw new ArgumentNullException(nameof(model));

			return await _hulkRepository.Update(id, model);
		}

		/// <summary>
		/// Deletes the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public async Task<bool> Delete(Guid id)
		{
			return await _hulkRepository.Delete(id);
		}
	}
}
