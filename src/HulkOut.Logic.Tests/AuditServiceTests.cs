using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HulkOut.Logic.Tests
{
	[TestClass]
	public class AuditServiceTests
	{
		private static AuditService AuditService()
		{
			var auditService = new AuditService();
			return auditService;
		}

		[TestMethod]
		public void GetAll_GivenNullFilter_ThrowsError()
		{
			//arrange
			var auditService = AuditService();

			//act
			var result = Assert.ThrowsException<ArgumentNullException>(() => { auditService.GetAll(null); });

			//assert
			Assert.IsNotNull(result);
			Assert.AreEqual("filter", result.ParamName);
		}
	}
}
